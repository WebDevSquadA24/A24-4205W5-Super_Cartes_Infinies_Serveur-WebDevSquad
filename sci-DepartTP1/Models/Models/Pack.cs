using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Pack
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public int NbCards { get; set; }

        public Rarity Rarity { get; set; }
    }
}
