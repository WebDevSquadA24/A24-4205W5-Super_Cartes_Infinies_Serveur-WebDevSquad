using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }

        public CardActivationEvent( MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match)
        {
            this.Events = new List<MatchEvent>();
            this.Events.Add(new AttackEvent(currentPlayerData, opposingPlayerData, match));
        }
    }
}
