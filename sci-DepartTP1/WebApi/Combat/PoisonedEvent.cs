using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PoisonedEvent : MatchEvent
    {
        public override string EventType { get { return "Poisoned"; } }

        public PoisonedEvent(PlayableCard card)
        {
            card.Health -= card.GetStatusValue((int)StatusEnum.Poisoned);
        }
    }
}
