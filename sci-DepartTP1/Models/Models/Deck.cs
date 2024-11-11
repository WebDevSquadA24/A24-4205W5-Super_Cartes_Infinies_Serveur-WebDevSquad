using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    [Table("Deck")]
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public bool IsCurrent { get; set; } = false;

        [ValidateNever]
        [JsonIgnore]
        [ForeignKey("OwnedCardId")]
        public virtual List<OwnedCard> OwnedCards { get; set; } = [];

        [ValidateNever]
        [JsonIgnore]
        public virtual Player Player { get; set; }
    }
}
