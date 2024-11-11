using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.VM
{
    /// <summary>
    /// Objet qui permet de sélectionner un pouvoir et de l'ajouter dans la list des pouvoirs.
    /// </summary>
    public class CardVM
    {
        public Card Card { get; set; }
        public List<SelectListItem>? AvailablePowers { get; set; }

        public int SelectedPowerId { get; set; }
        public int PowerValue { get; set; }

        

    }
}
