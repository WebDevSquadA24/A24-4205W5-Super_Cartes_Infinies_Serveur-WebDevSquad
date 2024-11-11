using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class ThornsEvent : MatchEvent
    {
        public override string EventType { get { return "Thorns"; } }

        public PlayableCard myCard { get; set; }

        public int ThornsDamage { get; set; }
        public int PlayerId { get; set; }
        public ThornsEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData,Match match, int index, int thornValue)
        {
            this.Events = new List<MatchEvent>();
            ThornsDamage = thornValue;
            PlayerId = currentPlayerData.PlayerId;
            if (currentPlayerData.BattleField.Count > 0 && opposingPlayerData.BattleField.Count > 0)
            {
                myCard = currentPlayerData.GetOrderedBattleField().Where(b => b.Index == index).First();
                myCard.Health -= thornValue;
                if(currentPlayerData.GetOrderedBattleField().Where(b => b.Index == index).First().Health <= 0)
                {
                    this.Events.Add(new CardDeathEvent(currentPlayerData, index));

                }
            }


            //if (opposingPlayerData.BattleField[index].Health > 0)
            //{
            //    Events.Add(new CardDamageEvent(currentPlayerData, opposingPlayerData, match, index));
            //}
        }
    }
}
