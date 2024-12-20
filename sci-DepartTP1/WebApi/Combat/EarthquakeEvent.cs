using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class EarthquakeEvent : MatchEvent
    {
        public override string EventType { get { return "Earthquake"; } }

        public int Value { get; set; }

        public EarthquakeEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int value)
        {
            Value = value;
            Earthquake(currentPlayerData, value);
            Earthquake(opposingPlayerData, value);
        }

        private void Earthquake(MatchPlayerData playerData, int value)
        {
            for (int i = 0; i < playerData.BattleField.Count; i++)
            {
                var playableCard = playerData.BattleField[i];
                playableCard.Health -= value;
                // Card death if no health
                if (playableCard.Health <= 0)
                {
                    if (Events == null) Events = new List<MatchEvent>();
                    Events.Add(new CardDeathEvent(playerData, playerData.BattleField.IndexOf(playableCard)));
                    i--;
                }
            }
        }
    }
}
