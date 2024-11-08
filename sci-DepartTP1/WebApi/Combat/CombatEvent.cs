using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CombatEvent : MatchEvent
    {
        public override string EventType { get { return "Combat"; } }


        // C'est ici qu'on check si il y a Power
        public CombatEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match) 
        {
            this.Events = new List<MatchEvent>();
            // Par carte on ajoute cet event
            for(int i= currentPlayerData.BattleField.Count-1 ; i >= 0; i--)
            {
                this.Events.Add(new CardActivationEvent(currentPlayerData, opposingPlayerData, match, i));

            }



        }

    }
}
