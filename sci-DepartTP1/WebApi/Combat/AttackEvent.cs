using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }

        public AttackEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match)
        {
            this.Events = new List<MatchEvent>();
            this.Events.Add(new CardDamageEvent(currentPlayerData, opposingPlayerData, match));
        }
    }
}
