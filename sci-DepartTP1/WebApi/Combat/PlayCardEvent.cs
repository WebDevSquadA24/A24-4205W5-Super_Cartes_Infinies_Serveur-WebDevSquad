using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
    }
}
