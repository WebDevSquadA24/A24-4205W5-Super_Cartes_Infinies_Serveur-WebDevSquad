using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class GameConfig:IModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de cartes à piger")]
        public int NbCardsToDraw { get; set; }
        [Display(Name = "Quantité de mana à recevoir")]
        public int NbManaToReceive { get; set; }

        public int NbMaxDeck { get; set; }

        public int NbMaxCard { get; set; }
    }
}
