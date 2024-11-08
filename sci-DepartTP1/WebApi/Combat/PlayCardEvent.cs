using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System.Text.RegularExpressions;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
        public int PlayableCardId { get; set; }

        public int PlayerId { get; set; }

        public bool CanMoveCard { get; set; }

        // TODO: Ajouter tout ce qui manque
        public PlayCardEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int playableCardId, bool yourTurn)
        {
            CanMoveCard = false;
            int maxCarte = 5;
            PlayerId = currentPlayerData.PlayerId;

            // C'est tu ton tour?
            if (yourTurn)
            {
                // T'as tu plus que 0 carte dans ta main
                if (currentPlayerData.Hand.Count > 0)
                {
                    PlayableCard playableCard = currentPlayerData.Hand.Where(h => h.Id == playableCardId).First();
                    PlayableCardId = playableCard.Id;


                    //Est-ce que t'as assez de Mana
                    if (playableCard.Card.Cost <= currentPlayerData.Mana)
                    {
                        // Est-ce qu'il y a de l'espace sur le terrain
                        if (currentPlayerData.BattleField.Count < maxCarte)
                        {
                            PlayableCardId = playableCardId;

                            currentPlayerData.Mana -= playableCard.Card.Cost;

                            currentPlayerData.AddCardToBattleField(playableCard);

                            CanMoveCard = true;
                        }
                    }
                }
            }
        }
    }
}
