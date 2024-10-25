using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name  { get; set; }

        public bool IsCurrent { get; set; }

        [ValidateNever]
        public virtual List<OwnedCardDeck> OwnedCardDecks { get; set; }
    }
}
