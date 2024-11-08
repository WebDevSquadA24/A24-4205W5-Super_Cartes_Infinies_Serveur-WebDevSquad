using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class CardDeathEvent : MatchEvent
    {
        public override string EventType { get { return "CardDeath"; } }

        public int PlayableCardId { get; set; }

        public int PlayerId { get; set; }

        public PlayableCard deadCard {  get; set; }
         public CardDeathEvent(MatchPlayerData deadCardPlayerData, int battleFieldId)
        {
            this.Events = new List<MatchEvent>();
            if (deadCardPlayerData.BattleField.Count >0) 
            {
                deadCard = deadCardPlayerData.BattleField[battleFieldId];
                PlayableCardId = deadCard.Id;
                PlayerId = deadCardPlayerData.PlayerId;

                deadCardPlayerData.RemoveCardFromBattleField(deadCard);
            }
        }
    }
}
