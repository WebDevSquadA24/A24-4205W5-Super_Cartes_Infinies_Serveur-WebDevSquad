using Models.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class MatchPlayerData : IModel
    {
		private const int STARTING_HEALTH = 20;

        public MatchPlayerData()
        {
        }

        // Utilisé par les tests
        public MatchPlayerData(int playerId)
		{
            PlayerId = playerId;
            Health = STARTING_HEALTH;
            CardsPile = new List<PlayableCard>();
            Hand = new List<PlayableCard>();
            BattleField = new List<PlayableCard>();
            Graveyard = new List<PlayableCard>();
        }

        public MatchPlayerData(Player p) : this(p.Id)
        {
            // TODO: Lors de l'intégration, remplacer par les cartes du joueur, on n'aura plus besoin de la liste de cartes
            CardsPile = p.Decks.Single(d => d.IsCurrent).OwnedCards.Select(oc => new PlayableCard(oc.Card)).ToList();
            //foreach (var card in p.OwnedCards.Select(c => c.Card)) {
            //    CardsPile.Add(new PlayableCard(card));
            //}
        }

        public int Id { get; set; }
		public int Health { get; set; }
        public int Mana { get; set; }


        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }

        // TODO: Il faut ordonner correctement toutes ces listes/stacks qui pourraient avoir un ordre différent quand on les obtient de la BD (mettre des indexes partout...)
        public virtual List<PlayableCard> CardsPile { get; set; }
        public virtual List<PlayableCard> Hand { get; set; }

        public virtual List<PlayableCard> BattleField { get; set; }
        public virtual List<PlayableCard> Graveyard { get; set; }


        public int IndexBattleField { get; set; } = 0;



        // Assurez-vous d'utiliser cette méthode pour votre logique de combat!
        public List<PlayableCard> GetOrderedBattleField()
        {
            // Retourner les cartes dans l'ordre de l'Index
            return BattleField.OrderBy(b=>b.Index).ToList();
        }

        public void AddCardToBattleField(PlayableCard playableCard)
        {
            // Ajouter la carte au BattleField et lui donner le bon index (En fonction du nombre de cartes déjà sur le BattleField)
            
            // Enlever du Hand
            Hand.Remove(playableCard);

            // On lui attribue son index
            playableCard.Index = IndexBattleField;

            // Ajout BattleField
            BattleField.Add(playableCard);

            // Mise à jour de l'IndexBattleField
            IndexBattleField = GetOrderedBattleField().Count();


        }
        public void RemoveCardFromBattleField(PlayableCard playableCard)
        {
            // Retirer la carte du BattleField
            // Atention: Il faut mettre les autres cartes du BattleField à jour!

            // Récupération de l'index du playableCard
            int indexDeadCard = playableCard.Index;

            // On enlève du BattleField
            BattleField.Remove(playableCard);

            // Ajout dans Graveyard
            Graveyard.Add(playableCard);

            // Décrémenter l'index du playableCard
            foreach(PlayableCard playable in GetOrderedBattleField())
            {
                if(playable.Index > indexDeadCard)
                {
                    playable.Index--;
                }
            }

            // Mise à jour de l'IndexBattleField
            IndexBattleField = GetOrderedBattleField().Count();
        }


    }
}

