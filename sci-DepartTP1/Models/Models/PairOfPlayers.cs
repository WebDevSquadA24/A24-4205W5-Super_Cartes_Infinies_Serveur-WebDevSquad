using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PairOfPlayers
    {
        public int Id { get; set; }

        public string UserAId { get; set; }

        public string UserBId { get; set; }

        public string OtherConnectionId {  get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual PlayerInfo PlayerInfo1 { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual PlayerInfo PlayerInfo2 { get; set; }


        public PairOfPlayers() { }

        public PairOfPlayers(PlayerInfo playerInfo1, PlayerInfo playerInfo2)
        {
            UserAId = playerInfo1.UserId;
            UserBId = playerInfo2.UserId;
            PlayerInfo1 = playerInfo1;
            PlayerInfo2 = playerInfo2;
        }
    }
}
