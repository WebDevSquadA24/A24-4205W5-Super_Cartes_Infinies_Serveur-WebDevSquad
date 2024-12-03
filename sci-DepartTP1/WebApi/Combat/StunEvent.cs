using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class StunEvent : MatchEvent
    {
        public override string EventType { get { return "Stun"; } }

        public StunEvent(PlayableCard currentCard, PlayableCard opponentCard)
        {
            opponentCard.AddStatusValue((int)StatusEnum.Stunned, currentCard.GetPowerValue(Power.STUN_ID));
        }
    }
}
