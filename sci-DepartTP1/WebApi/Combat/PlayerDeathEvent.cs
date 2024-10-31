using Super_Cartes_Infinies.Combat;
namespace WebApi.Combat
{
    public class PlayerDeathEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDeath"; } }
    }
}
