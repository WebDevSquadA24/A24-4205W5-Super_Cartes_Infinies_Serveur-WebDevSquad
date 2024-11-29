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
            if (opponentCard.PlayableCardStatuses.Where(pcs => pcs.StatusId == (int)StatusEnum.Poisoned).IsNullOrEmpty())
            {
                opponentCard.PlayableCardStatuses.Add(new PlayableCardStatus()
                {
                    StatusId = (int)StatusEnum.Poisoned,
                    Value = currentCard.GetPowerValue(Power.POISON_ID)
                });
            }
            else
            {
                opponentCard.PlayableCardStatuses.Single(pcs => pcs.StatusId == (int)StatusEnum.Poisoned).Value += currentCard.GetPowerValue(Power.POISON_ID); ;
            }
        }
    }
}
