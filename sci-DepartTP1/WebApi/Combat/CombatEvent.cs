using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CombatEvent : MatchEvent
    {
        public override string EventType { get { return "Combat"; } }


        public CombatEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbManaPerTurn) 
        {
            // C'est ici qu'on verifie si il y a des pouvoirs ou non
            this.Events.Add(new CardActivationEvent(match, currentPlayerData, opposingPlayerData, nbManaPerTurn));
        }

    }
}
