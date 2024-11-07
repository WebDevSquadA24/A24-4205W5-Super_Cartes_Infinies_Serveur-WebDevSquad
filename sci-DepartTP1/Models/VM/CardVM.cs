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
        public SelectList AvailablePowers { get; set; }

        private int _selectedItemId;

        public int SelectedItemId
        {
            get { return _selectedItemId; }
            set
            {
                foreach (var power in AvailablePowers)
                {
                    _selectedItemId = int.Parse(power.Value) ;
                }
            }
        }
        public int PowerValue { get; set; }

        

    }
}
