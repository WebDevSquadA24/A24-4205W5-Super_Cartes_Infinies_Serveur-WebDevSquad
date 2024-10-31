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
            //int initBattLeFieldCount = currentPlayerData.BattleField.Count;
            //int nbDead = 0;
            //for (int i =0; i < initBattLeFieldCount; i++)
            //{
            //    if(opposingPlayerData.BattleField.Count  > i)
            //    {
            //        // CardDamageEvent
            //        opposingPlayerData.BattleField[i].Health -= currentPlayerData.BattleField[i].Attack;
            //        currentPlayerData.BattleField[i].Health -= opposingPlayerData.BattleField[i].Attack;

            //        // Opponent Card dead
            //        if (opposingPlayerData.BattleField[i].Health <= 0)
            //        {
            //            this.Events.Add(new CardDeathEvent(opposingPlayerData, i));
            //        }

            //        // My Card dead
            //        if(currentPlayerData.BattleField[i].Health <= 0)
            //        {
            //            this.Events.Add(new CardDeathEvent(currentPlayerData, i));
            //            nbDead++;

            //        }
            //    }
            //    else
            //    {
            //        this.Events.Add(new PlayerDamageEvent(opposingPlayerData,currentPlayerData, currentPlayerData.BattleField[i - nbDead], match));
            //    }

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
                match.nbDead++;

            }



        }
    }

}
