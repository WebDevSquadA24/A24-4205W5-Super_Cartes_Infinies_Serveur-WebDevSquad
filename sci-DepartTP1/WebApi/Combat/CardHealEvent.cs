using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardHealEvent : MatchEvent
    {
        public override string EventType { get { return "CardHeal"; } }
        public int Index { get; set; }
        public int HealValue { get; set; }

        public CardHealEvent(PlayableCard toHealCard, int healValue)
        {
            toHealCard.Health += healValue;
            Index = toHealCard.Index;
            HealValue = healValue;
            if(toHealCard.Card.Health > toHealCard.MaxHealth)
            {
                toHealCard.Health = toHealCard.MaxHealth;
            }

        }
    }
}
