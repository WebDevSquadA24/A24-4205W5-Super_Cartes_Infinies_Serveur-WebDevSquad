using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class ThornsEvent : MatchEvent
    {
        public override string EventType { get { return "Thorns"; } }
        public ThornsEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData,Match match, int index, int thornValue)
        {
            this.Events = new List<MatchEvent>();
            if (currentPlayerData.BattleField.Count > 0 && opposingPlayerData.BattleField.Count > 0)
            {
                currentPlayerData.BattleField[index].Health -= thornValue;
            }


            if (opposingPlayerData.BattleField[index].Health > 0)
            {
                Events.Add(new CardDamageEvent(currentPlayerData, opposingPlayerData, match, index));
            }
        }
    }
}
