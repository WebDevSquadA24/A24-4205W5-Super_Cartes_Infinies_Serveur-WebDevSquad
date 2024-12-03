using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
namespace WebApi.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }
        public PlayableCard myCard { get; set; }

        public PlayableCard opponentCard { get; set; }

        // On va attaquer. On laisse just la partie de damage pour le CardDamageEvent.
        public AttackEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, Match match, int index)
        {
            this.Events = new List<MatchEvent>();
           

            

            if (opposingPlayerData.BattleField.Count > index)
            {
                
                myCard = currentPlayerData.GetOrderedBattleField().Where(b => b.Index == index).First();
                opponentCard = opposingPlayerData.GetOrderedBattleField().Where(b => b.Index == index).First();

                if (opponentCard.HasPower(Power.THORNS_ID))
                {
                    int thornValue = opponentCard.GetPowerValue(Power.THORNS_ID);
                    this.Events.Add(new ThornsEvent(currentPlayerData, opposingPlayerData, match, index, thornValue));
                }

                if (myCard.Health > 0)
                {

                    if (myCard.HasPower(Power.FIRST_STRIKE_ID))
                    {
                        this.Events.Add(new FirstStrikeEvent(currentPlayerData, opposingPlayerData, match, index));
                    }
                    if (myCard.HasPower(Power.POISON_ID))
                    {
                        this.Events.Add(new PoisonEvent(myCard, opponentCard));
                    }
                    if (myCard.HasPower(Power.STUN_ID))
                    {
                        this.Events.Add(new StunEvent(myCard, opponentCard));
                    }
                    if (myCard.Health > 0)
                    {
                        if (!(opponentCard.Health <= 0))
                        {
                            this.Events.Add(new CardDamageEvent(currentPlayerData, opposingPlayerData, match, index));

                        }
                    }
                }
            }
            else
            {
                this.Events.Add(new PlayerDamageEvent(opposingPlayerData, currentPlayerData, currentPlayerData.BattleField[index], match));
            }

                

            

        }
    }
}
