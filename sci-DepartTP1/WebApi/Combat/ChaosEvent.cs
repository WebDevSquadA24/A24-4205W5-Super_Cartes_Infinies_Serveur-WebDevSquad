using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class ChaosEvent : MatchEvent
    {
        public override string EventType { get { return "Chaos"; } }
        public ChaosEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            Chaos(currentPlayerData);
            Chaos(opposingPlayerData);
        }

        private void Chaos(MatchPlayerData playerData)
        {
            for (int i = 0; i < playerData.BattleField.Count; i++)
            {
                var playableCard = playerData.BattleField[i];
                // Inverse stats
                var health = playableCard.Health;
                playableCard.Health = playableCard.Attack;
                playableCard.Attack = health;
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
