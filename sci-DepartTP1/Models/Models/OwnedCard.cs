using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Models.Models;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class OwnedCard : IModel
    {
        public int Id { get; set; }

        [JsonIgnore]
        public virtual Player Player { get; set; }
        public virtual Card Card { get; set; }

        [ValidateNever]
        public virtual List<Deck> Decks { get; set; } = [];
    }
}
