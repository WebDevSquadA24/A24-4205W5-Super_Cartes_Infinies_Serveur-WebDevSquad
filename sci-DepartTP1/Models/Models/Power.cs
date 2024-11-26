using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Models.Models
{
    public class Power
    {
        public const int FIRST_STRIKE_ID = 1;
        public const int THORNS_ID = 2;
        public const int HEAL_ID = 3;
        public const int LOVE_OF_JESUS_CHRIST = 4;
        public const int CHAOS_ID = 5;
        public const int POISON_ID = 6;
        public const int STUN_ID = 7;
        public const int EARTHQUAKE_ID = 8;
        public const int RANDOM_PAIN_ID = 9;
        // If Dies with Chaos, Everycard Dies too
        public const int TALIBAN_ID = 10; 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? IconURL { get; set; }


        [ValidateNever]
        [JsonIgnore]
        public virtual List<CardPower>? CardPowers { get; set; }
    }
}
