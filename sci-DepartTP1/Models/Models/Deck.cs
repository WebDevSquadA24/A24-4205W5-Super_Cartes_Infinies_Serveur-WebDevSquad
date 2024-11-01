using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Super_Cartes_Infinies.Models;
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
        public string Name { get; set; }

        public bool IsCurrent { get; set; } = false;

        [ValidateNever]
        public virtual List<OwnedCard> OwnedCards { get; set; } = [];
    }
}
