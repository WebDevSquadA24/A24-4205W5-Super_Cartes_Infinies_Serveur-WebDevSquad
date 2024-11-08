using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class PlayerDamageEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDamage"; } }
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }
        public int Damage { get; set; }

        public PlayerDamageEvent(MatchPlayerData opposingPlayerData, MatchPlayerData currentPlayerData, PlayableCard playable, Match match)
        {
            this.Events = new List<MatchEvent>();
            opposingPlayerData.Health -= playable.Attack;
            Damage = playable.Attack;
            PlayerId = opposingPlayerData.PlayerId;
            PlayableCardId = playable.Id;
            if (opposingPlayerData.Health <= 0) 
            {
                this.Events.Add(new PlayerDeathEvent(currentPlayerData, match, opposingPlayerData));
            }

        }
    }
}
