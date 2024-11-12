using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class HealEvent : MatchEvent
    {
        public override string EventType { get { return "Heal"; } }
        public int Index { get; set; }

        public HealEvent(MatchPlayerData playerData, int healValue)
        {
            this.Events = new List<MatchEvent>();
            for (int i =0; i< playerData.GetOrderedBattleField().Count(); i++)
            {
                Events.Add(new CardHealEvent(playerData.GetOrderedBattleField().Where(p=>p.Index == i).First(), healValue));
            }
        }
    }
}
