using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
    public enum Rarity { Commune, Rare, Épique, Légendaire}
    public class Card:IModel
    {
        public Card() {
            Rarity = Rarity.Commune;
        }

        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; } = "";
        [Display(Name = "Attaque")]
        public int Attack { get; set; }
        [Display(Name = "Santé")]
        public int Health { get; set; }
        [Display(Name = "Coût")]
        public int Cost { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = "";
        [Display(Name = "Rareté de la carte")]
        public bool IsSpell { get; set; } = false;
        public Rarity Rarity { get; set; }

        [ValidateNever]
        public virtual List<CardPower> CardPowers { get; set; } = new List<CardPower>();
    }
}

