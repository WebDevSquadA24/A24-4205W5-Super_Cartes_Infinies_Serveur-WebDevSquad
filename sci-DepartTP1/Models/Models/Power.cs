using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Power
    {
        public const int FIRST_STRIKE_ID = 1;
        public const int THORNS_ID = 2;
        public const int HEAL_ID = 3;
        public const int LoveOfJesusChrist_ID = 4;

        public int Id { get; set; }

        [ValidateNever]
        public virtual List<CardPower>? CardPowers { get; set; }
    }
}
