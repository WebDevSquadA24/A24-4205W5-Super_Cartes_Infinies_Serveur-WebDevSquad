using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class LoveOfJesusChristEvent : MatchEvent
    {
        public override string EventType { get { return "LoveOfJesusChrist"; } }

        public LoveOfJesusChristEvent(MatchPlayerData playerData)
        {
            if(playerData.Health < 20)
            {
                playerData.Health++;

            }
           
        }
    }
}
