using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Models.Interfaces;

namespace Super_Cartes_Infinies.Models
{
    public class Card:IModel
	{
		public Card() { }

		public int Id { get; set; }

		[Display(Name = "Nom")]
		public string Name { get; set; } = "";
        [Display(Name = "Attaque")]
        public int Attack { get; set; }
        [Display(Name = "Santé")]
        public int Health { get; set; }
        [Display(Name = "Coût")]
        public int Cost { get; set; }
        [Display(Name = "URL de l'image")]
        public string ImageUrl { get; set; } = "";
    }
}

