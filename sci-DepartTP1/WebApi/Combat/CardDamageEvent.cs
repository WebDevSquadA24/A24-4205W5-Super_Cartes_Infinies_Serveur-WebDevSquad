using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType { get { return "CardDamage"; } }
        public PlayableCard myCard { get; set; }
        public PlayableCard opponentCard { get; set; }
        public int DamageToMe { get; set; }
        public int DamageToOpponent { get; set; }

        public int Index { get; set; }

        public int PlayerId { get; set; }





        public CardDamageEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match, int index)
        {
            Index = index;

            this.Events = new List<MatchEvent>();


            myCard = currentPlayerData.GetOrderedBattleField().Where(b => b.Index == index).First();
            opponentCard = opposingPlayerData.GetOrderedBattleField().Where(b => b.Index == index).First();

            myCard.Health -= opponentCard.Attack;
            opponentCard.Health -= myCard.Attack;

            DamageToMe = opponentCard.Attack;
            DamageToOpponent = myCard.Attack;
            PlayerId = currentPlayerData.PlayerId;

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
