using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class HealEvent : MatchEvent
    {
        public override string EventType { get { return "Heal"; } }

        public HealEvent(MatchPlayerData playerData, int healValue)
        {
            this.Events = new List<MatchEvent>();
            for (int i =0; i< playerData.BattleField.Count; i++)
            {
                Events.Add(new CardHealEvent(playerData.BattleField[i], healValue));
            }
        }
    }
}
