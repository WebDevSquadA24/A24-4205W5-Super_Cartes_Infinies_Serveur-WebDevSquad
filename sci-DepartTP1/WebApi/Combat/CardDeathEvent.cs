using Super_Cartes_Infinies.Combat;
namespace WebApi.Combat
{
    public class CardDeathEvent : MatchEvent
    {
        public override string EventType { get { return "CardDeath"; } }
    }
}
