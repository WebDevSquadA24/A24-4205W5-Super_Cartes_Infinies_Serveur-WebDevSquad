using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? IconUrl { get; set; }
    }
    public enum StatusEnum{ Poisoned = 1, Stunned }
}
