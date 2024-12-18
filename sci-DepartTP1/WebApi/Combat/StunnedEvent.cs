using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class StunnedEvent : MatchEvent
    {
        public override string EventType { get { return "Stunned"; } }

        public int Index { get; set; }

        public StunnedEvent(PlayableCard card)
        {
            card.SubtractStatusValue((int)StatusEnum.Stunned, 1);

            Index = card.Index;
        }
    }
}
