using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OwnedCardDeck
    {
        public int Id { get; set; }
        public virtual Deck Deck { get; set; }
        public virtual OwnedCard OwnedCard { get; set; }
    }
}
