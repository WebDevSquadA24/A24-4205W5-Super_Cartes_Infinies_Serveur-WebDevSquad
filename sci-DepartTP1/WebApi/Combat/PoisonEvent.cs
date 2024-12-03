using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PoisonEvent : MatchEvent
    {
        public override string EventType { get { return "Poison"; } }

        public PoisonEvent(PlayableCard currentCard, PlayableCard opponentCard)
        {
            opponentCard.AddStatusValue((int)StatusEnum.Poisoned, currentCard.GetPowerValue(Power.POISON_ID));
        }
    }
}
