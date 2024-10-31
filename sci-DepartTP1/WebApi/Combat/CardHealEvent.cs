using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardHealEvent : MatchEvent
    {
        public override string EventType { get { return "CardHeal"; } }

        public CardHealEvent(PlayableCard toHealCard, int healValue)
        {
            toHealCard.Health += healValue;
            if(toHealCard.Health > toHealCard.MaxHealth)
            {
                toHealCard.Health = toHealCard.MaxHealth;
            }

        }
    }
}
