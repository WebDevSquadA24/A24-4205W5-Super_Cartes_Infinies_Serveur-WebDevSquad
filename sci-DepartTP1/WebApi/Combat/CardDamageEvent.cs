using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType { get { return "CardDamage"; } }
        public PlayableCard myCard { get; set; }
        public PlayableCard opponentCard { get; set; }


        public CardDamageEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match, int index)
        {

            this.Events = new List<MatchEvent>();


            myCard = currentPlayerData.BattleField[index];
            opponentCard = opposingPlayerData.BattleField[index];

            myCard.Health -= opponentCard.Attack;
            opponentCard.Health -= myCard.Attack;

            //Opponent Card Dead
            if (opponentCard.Health <= 0)
            {
                this.Events.Add(new CardDeathEvent(opposingPlayerData, index));
            }

            // My Card dead
            if (myCard.Health <= 0)
            {
                this.Events.Add(new CardDeathEvent(currentPlayerData, index));

            }



        }
    }

}
