using Super_Cartes_Infinies.Models;

namespace Models.Models
{
    public class CardPower
    {
        public int Id { get; set; }
        public virtual Card Card { get; set; }
        public int CardId { get; set; }
        public virtual Power Power { get; set; }
        public int PowerId { get; set; }
        public int Value { get; set; }
    }
}
