using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }

        public PlayableCard myCard { get; set; }
        // On vérifie l'existence des Power et ajouter les Events en conséquent.
        public CardActivationEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match, int index)
        {
            this.Events = new List<MatchEvent>();

            myCard = currentPlayerData.BattleField[index - match.nbDead];
            // Thorns
            if (myCard.HasPower(2))
            {
                this.Events.Add(new ThornsEvent());
            }

            // Heal
            if (myCard.HasPower(3))
            {
                this.Events.Add(new HealEvent());
            }



            this.Events.Add(new AttackEvent(currentPlayerData, opposingPlayerData, match, index));

            

        }
    }
}
