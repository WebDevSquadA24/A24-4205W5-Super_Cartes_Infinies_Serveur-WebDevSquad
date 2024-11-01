using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class ThornsEvent : MatchEvent
    {
        public override string EventType { get { return "Thorns"; } }

        public PlayableCard myCard { get; set; }
        public ThornsEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData,Match match, int index, int thornValue)
        {
            this.Events = new List<MatchEvent>();
            if (currentPlayerData.BattleField.Count > 0 && opposingPlayerData.BattleField.Count > 0)
            {
                myCard = currentPlayerData.BattleField[index];
                myCard.Health -= thornValue;
                if(currentPlayerData.BattleField[index].Health <= 0)
                {

                    currentPlayerData.BattleField.Remove(myCard);
                    currentPlayerData.Graveyard.Add(myCard);

                }
            }


            //if (opposingPlayerData.BattleField[index].Health > 0)
            //{
            //    Events.Add(new CardDamageEvent(currentPlayerData, opposingPlayerData, match, index));
            //}
        }
    }
}
