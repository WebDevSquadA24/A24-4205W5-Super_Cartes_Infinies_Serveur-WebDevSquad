﻿using Models.Interfaces;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class StarterCard:IModel
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
