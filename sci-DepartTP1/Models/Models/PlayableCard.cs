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
		public virtual List<PlayableCardStatus> PlayableCardStatuses { get; set; } = [];

        public bool HasPower(int powerId)
        {
			// Return true if the Card has that power
			bool hasPower = false;
			if(Card.CardPowers == null)
			{
				return false;
			}

			if (Card.CardPowers!.Select(cp => cp.PowerId).Contains(powerId)) 
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
			if (PlayableCardStatuses.Select(pcs => pcs.Status.Id).Contains(statusId)) return true;
			return false;
		}

		public int GetStatusValue(int statusId)
		{
			if (!HasStatus(statusId)) return 0;

			return PlayableCardStatuses.First(pcs => pcs.Status.Id == statusId).Value;
		}
    }
}

