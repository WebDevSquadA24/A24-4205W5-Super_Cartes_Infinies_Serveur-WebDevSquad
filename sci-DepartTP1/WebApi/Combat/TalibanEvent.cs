using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class TalibanEvent : MatchEvent
    {
        public override string EventType { get { return "Taliban"; } }

        public TalibanEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int index)
        {
            Events = new List<MatchEvent>();
            Events.Add(new CardDeathEvent(currentPlayerData, index));
            Events.Add(new CardDeathEvent(opposingPlayerData, index));
        }
    }
}
