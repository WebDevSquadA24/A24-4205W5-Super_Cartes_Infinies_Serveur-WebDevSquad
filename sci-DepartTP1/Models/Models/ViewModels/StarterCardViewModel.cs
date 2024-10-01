using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.ViewModels
{
    public class StarterCardViewModel
    {
        public int SelectedCardId { get; set; }
        [ValidateNever]
        public List<Card> Cards { get; set; }
        [ValidateNever]
        public StarterCard StarterCard { get; set; }
    }
}
