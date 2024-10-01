using Models.Interfaces;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class OwnedCard : IModel
    {
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual Card Card { get; set; }
    }
}
