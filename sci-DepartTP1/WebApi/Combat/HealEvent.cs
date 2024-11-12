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
            int cpt = playerData.GetOrderedBattleField().Count();
            for (int i =0; i< cpt; i++)
            {
                PlayableCard playable = playerData.BattleField.Where(p => p.Index == i).First();
                Events.Add(new CardHealEvent(playable, healValue));
            }
        }
    }
}
