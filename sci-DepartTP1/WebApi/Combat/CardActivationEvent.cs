using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }
    }
}
