using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
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
    public class PowerVM
    {
        public Power SelectedPower { get; set; }
        List<SelectListItem> SelectListPowers { get; set; }
    }
}
