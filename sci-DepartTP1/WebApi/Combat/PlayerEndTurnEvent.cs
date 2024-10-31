using Super_Cartes_Infinies.Models;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerEndTurnEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerEndTurn"; } }
        public int PlayerId { get; set; }

        // L'évènement lorsqu'un joueur termine son tour
        public PlayerEndTurnEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbManaPerTurn)
        {
            match.nbDead = 0;
            this.PlayerId = currentPlayerData.PlayerId;
            this.Events = new List<MatchEvent>();

            match.IsPlayerATurn = !match.IsPlayerATurn;

            this.Events.Add(new PlayerStartTurnEvent(opposingPlayerData, nbManaPerTurn));
            this.Events.Add(new CombatEvent(currentPlayerData, opposingPlayerData, match));

        }

    }
}
