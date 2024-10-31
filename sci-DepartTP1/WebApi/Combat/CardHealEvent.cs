using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat
{
    public class CardHealEvent : MatchEvent
    {
        public override string EventType { get { return "CardHeal"; } }
    }
}
