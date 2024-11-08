using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class PlayerDeathEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDeath"; } }
        

        public PlayerDeathEvent(MatchPlayerData currentPlayerData, Match match, MatchPlayerData losingPlayer)
        {
            this.Events = new List<MatchEvent>()
            {
                new EndMatchEvent(match, currentPlayerData, losingPlayer)
            };
        }
    }
}
