using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class GameConfig:IModel
    {
        public int Id { get; set; }
        public int NbCardsToDraw { get; set; }
        public int NbManaToReceive { get; set; }
    }
}
