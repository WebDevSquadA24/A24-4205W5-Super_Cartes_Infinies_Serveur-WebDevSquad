using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class FirstStrikeEvent : MatchEvent
    {
        public override string EventType { get { return "FirstStrike"; } }

        public PlayableCard myCard { get; set; }
        public PlayableCard opponentCard { get; set; }

        public FirstStrikeEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match, int index)
        {
            this.Events = new List<MatchEvent>();

            myCard = currentPlayerData.BattleField[index];
            opponentCard = opposingPlayerData.BattleField[index];

            if (myCard.Attack >= opponentCard.Health)
            {
                opponentCard.Health -= myCard.Attack;

                opposingPlayerData.RemoveCardFromBattleField(opponentCard);
            }
            else
            {
                this.Events.Add(new CardDamageEvent(currentPlayerData, opposingPlayerData, match, index));
            }
        }
    }
}
