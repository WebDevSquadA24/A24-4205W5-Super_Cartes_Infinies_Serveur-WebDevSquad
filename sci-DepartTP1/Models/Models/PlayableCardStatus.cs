using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlayableCardStatus
    {
        public int Id { get; set; }

        [JsonIgnore]
        public virtual PlayableCard PlayableCard { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int Value { get; set; }
    }
}
