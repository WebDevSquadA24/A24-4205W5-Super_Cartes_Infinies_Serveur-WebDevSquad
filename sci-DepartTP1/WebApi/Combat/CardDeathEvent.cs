using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class CardDeathEvent : MatchEvent
    {
        public override string EventType { get { return "CardDeath"; } }

        public PlayableCard deadCard {  get; set; }
         public CardDeathEvent(MatchPlayerData deadCardPlayerData, int battleFieldId)
        {
            this.Events = new List<MatchEvent>();
            if (deadCardPlayerData.BattleField.Count >0) 
            {
                deadCard = deadCardPlayerData.BattleField[battleFieldId];
                deadCardPlayerData.BattleField.RemoveAt(battleFieldId);
                deadCardPlayerData.Graveyard.Add(deadCard);
            }
        }
    }
}
