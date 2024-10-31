using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class PlayerDamageEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDamage"; } }

        public PlayerDamageEvent(MatchPlayerData opposingPlayerData, MatchPlayerData currentPlayerData, PlayableCard playable, Match match)
        {
            this.Events = new List<MatchEvent>();
            opposingPlayerData.Health -= playable.Attack;
            if (opposingPlayerData.Health <= 0) 
            {
                this.Events.Add(new PlayerDeathEvent(currentPlayerData, match));
            }

        }
    }
}
