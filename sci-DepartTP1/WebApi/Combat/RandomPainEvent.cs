using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class RandomPainEvent : MatchEvent
    {
        public override string EventType { get { return "RandomPain"; } }

        public int randomDamage { get; set; }
        public int targetIndex { get; set; }
        public RandomPainEvent(MatchPlayerData opposingPlayerData)
        {
            var nbCards = opposingPlayerData.GetOrderedBattleField().Count;
            if (nbCards > 0)
            {
                Random r = new Random();
                targetIndex = r.Next(0, nbCards);
                var targetCard = opposingPlayerData.GetOrderedBattleField()[targetIndex];
                randomDamage = r.Next(0, 7);
                targetCard.Health -= randomDamage;

                if (targetCard.Health <= 0)
                {
                    if (Events == null) Events = new List<MatchEvent>();
                    Events.Add(new CardDeathEvent(opposingPlayerData, opposingPlayerData.BattleField.IndexOf(targetCard)));
                }
            }
        }
    }
}
