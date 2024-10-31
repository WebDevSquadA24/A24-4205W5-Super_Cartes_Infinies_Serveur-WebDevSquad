using Super_Cartes_Infinies.Combat;
namespace WebApi.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }
    }
}
