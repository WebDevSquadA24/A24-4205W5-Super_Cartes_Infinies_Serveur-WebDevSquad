using Super_Cartes_Infinies.Combat;
namespace WebApi.Combat
{
    public class PlayerDamageEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDamage"; } }
    }
}
