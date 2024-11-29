using Models.Models;
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

            myCard = currentPlayerData.BattleField[index];

           
            
            // Heal
            if (myCard.HasPower(Power.HEAL_ID))
            {
                int healValue = myCard.GetPowerValue(Power.HEAL_ID);
                this.Events.Add(new HealEvent(currentPlayerData, healValue));
            }

            // LoveOfJesusChrist
            if (myCard.HasPower(Power.LOVE_OF_JESUS_CHRIST))
            {
                this.Events.Add(new LoveOfJesusChristEvent(currentPlayerData));
            }

            //Chaos
            if (myCard.HasPower(Power.CHAOS_ID))
            {
                this.Events.Add(new ChaosEvent(currentPlayerData, opposingPlayerData));
            }

            this.Events.Add(new AttackEvent(currentPlayerData, opposingPlayerData, match, index));

            

        }
    }
}
