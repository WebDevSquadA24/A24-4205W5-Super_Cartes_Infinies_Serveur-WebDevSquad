using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class PlayableCard : IModel
	{
		public PlayableCard()
		{
		}

		public PlayableCard(Card c)
		{
			Card = c;
			Health = c.Health;
			Attack = c.Attack;
			MaxHealth = Card.Health;
		}

		public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
		public int MaxHealth { get; set; }
		public int Attack { get; set; }
        public int Index { get; set; }

		[ValidateNever]
		public virtual List<PlayableCardStatus> PlayableCardStatuses { get; set; } = new List<PlayableCardStatus>();

        public bool HasPower(int powerId)
        {
			// Return true if the Card has that power
			bool hasPower = false;
			if(Card.CardPowers == null)
			{
				return false;
			}

			if (Card.CardPowers!.Select(cp => cp.Power.Id).Contains(powerId)) 
				hasPower = true;

			return hasPower;
        }
        public int GetPowerValue(int powerId)
        {
			// Return the value of that power for that card. 
			// Simply returns 0 if the card doesn't have the power.
			if (!HasPower(powerId))
			{
				return 0;
			}

			CardPower card = Card.CardPowers!.Where(cp => cp.PowerId == powerId).First();

            return card.Value;
        }

		public bool HasStatus(int statusId)
		{
			if (PlayableCardStatuses.Select(pcs => pcs.StatusId).Contains(statusId)) return true;
			return false;
		}

		public int GetStatusValue(int statusId)
		{
			if (!HasStatus(statusId)) return 0;

			return PlayableCardStatuses.First(pcs => pcs.StatusId == statusId).Value;
		}

		public void AddStatusValue(int statusId, int value)
		{
            if (HasStatus(statusId))
            {
                PlayableCardStatuses.Single(pcs => pcs.StatusId == statusId).Value += value;
            }
            else
            {
                PlayableCardStatuses.Add(new PlayableCardStatus()
                {
                    StatusId = statusId,
                    Value = value,
                });
            }
        }

		public void SubtractStatusValue(int statusId, int value)
		{
            var playableCardStatus = PlayableCardStatuses.Single(pcs => pcs.StatusId == statusId);

            playableCardStatus.Value -= value;

            if (playableCardStatus.Value <= 0)
            {
                PlayableCardStatuses.Remove(playableCardStatus);
            }
        }
    }
}

