using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class StunnedEvent : MatchEvent
    {
        public override string EventType { get { return "Stunned"; } }

        public StunnedEvent(PlayableCard card)
        {
            card.SubtractStatusValue((int)StatusEnum.Stunned, 1);
        }
    }
}
