using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class RandomPainEvent : MatchEvent
    {
        public override string EventType { get { return "RandomPain"; } }

        public int Value { get; set; }
        public int Index { get; set; }

        public RandomPainEvent(MatchPlayerData opposingPlayerData)
        {
            var nbCards = opposingPlayerData.GetOrderedBattleField().Count;
            if (nbCards > 0)
            {
                Random r = new Random();
                Index = r.Next(0, nbCards);
                var targetCard = opposingPlayerData.GetOrderedBattleField()[Index];
                Value = r.Next(0, 7);
                targetCard.Health -= Value;

                if (targetCard.Health <= 0)
                {
                    if (Events == null) Events = new List<MatchEvent>();
                    Events.Add(new CardDeathEvent(opposingPlayerData, opposingPlayerData.BattleField.IndexOf(targetCard)));
                }
            }
        }
    }
}
