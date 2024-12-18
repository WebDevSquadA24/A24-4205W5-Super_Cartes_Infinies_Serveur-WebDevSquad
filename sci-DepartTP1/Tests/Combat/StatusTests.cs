using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Services;
using WebApi.Combat;

namespace Tests.Combat
{
    [TestClass]
    public class StatusTests : BaseTests
    {
        public StatusTests()
        {

        }

        [TestInitialize]
        public void Init()
        {
            base.Init();
        }


        [TestMethod]
        public void ChaosTest()
        {
            var cp = new CardPower
            {
                Power = _powerChaos,
                Card = _cardA,
                PowerId = Power.CHAOS_ID
            };

            _cardA.CardPowers.Add(cp);

            _playableCardA.Attack = 10;
            _playableCardB.Attack = 10;
            _playableCardC.Attack = 0;

            //Expected values
            int healthA = _playableCardA.Attack - _playableCardB.Health;
            int attackA = _playableCardA.Health;
            int healthB = _playableCardB.Attack - _playableCardA.Health;
            var attackB = _playableCardB.Health;
            
            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);
            _currentPlayerData.AddCardToBattleField(_playableCardC);

            var endTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData,_opposingPlayerData,NB_MANA_PER_TURN);



            Assert.AreEqual(healthA, _playableCardA.Health);
            Assert.AreEqual(attackA, _playableCardA.Attack);

            Assert.AreEqual(healthB, _playableCardB.Health);
            Assert.AreEqual(attackB, _playableCardB.Attack);

            // Vérifier carte C Death
            Assert.AreEqual(_playableCardC, _currentPlayerData.Graveyard[0]);
        }

        [TestMethod]
        public void PoisonTest()
        {
            var cp = new CardPower
            {
                Power = _powerPoison,
                Card = _cardA,
                Value = 1,
                PowerId = Power.POISON_ID
            };
            _playableCardA.Attack = 0;
            _playableCardB.Attack = 0;

            _cardA.CardPowers.Add(cp);

            //Expected
            int healthB = _playableCardB.Health - 3;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            // TODO: Mieux d'ajouter des vérifications de status et de health entre les PlayerEndTurnEvent
            var endTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            var endTurnEvent1 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);

            var endTurnEvent2 = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            var endTurnEvent3 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(healthB, _playableCardB.Health);
        }

        [TestMethod]
        public void StunTest()
        {
            var cp = new CardPower
            {
                Power = _powerStun,
                Card = _cardA,
                Value = 2,
                PowerId = Power.STUN_ID
            };

            _playableCardA.Attack = 1;
            _playableCardA.Health= 10;

            _playableCardB.Attack = 1;
            _playableCardB.Health = 10;

            _cardA.CardPowers.Add(cp);

            //Expected
            _currentPlayerData.Health = 20;
            int healthA = _currentPlayerData.Health - 1;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var endTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);
            _currentPlayerData.RemoveCardFromBattleField(_playableCardA);

            // TODO: Bonne idée de vérifier la valeur du Status Stunned entre les PlayeEndTurnEvent
            // NO ATTACK
            var endTurnEvent1 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);
            Assert.AreEqual(1, _playableCardB.GetStatusValue((int)StatusEnum.Stunned));
            var endTurnEvent2 = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            // NO ATTACK
            var endTurnEvent3 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);
            Assert.AreEqual(0, _playableCardB.GetStatusValue((int)StatusEnum.Stunned));
            var endTurnEvent4 = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            // YES ATTACK
            var endTurnEvent5 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(healthA, _currentPlayerData.Health);
        }

        [TestMethod]
        public void EarthquakeTest()
        {
            var cp = new CardPower
            {
                Power = _powerEarthquake,
                Card = _cardMagic,
                Value = 2,
                PowerId = Power.EARTHQUAKE_ID
            };

            _playableCardA.Attack = 1;
            _playableCardA.Health = 2;

            _playableCardB.Attack = 1;
            _playableCardB.Health = 10;

            _cardMagic.CardPowers.Add(cp);

            //Expected
            
            int healthA = _playableCardA.Health - _playableCardMagic.GetPowerValue(Power.EARTHQUAKE_ID);
            int healthB = _playableCardB.Health - _playableCardMagic.GetPowerValue(Power.EARTHQUAKE_ID);

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);
            _currentPlayerData.Hand.Add(_playableCardMagic);

            var playEvent = new PlayCardEvent(_currentPlayerData, _opposingPlayerData, _playableCardMagic.Id, true);


            // TODO: Bonne idée de faire mourrir une carte pour vérifier que ça fonctionne bien
            Assert.AreEqual(healthA, _playableCardA.Health);
            Assert.AreEqual(_playableCardA, _currentPlayerData.Graveyard[0]);
            Assert.AreEqual(healthB, _playableCardB.Health);

            // TODO: Vérifier que la carte Spell n'est plus sur le BattleField
            Assert.IsTrue(_currentPlayerData.BattleField.IsNullOrEmpty());
            Assert.AreEqual(_playableCardMagic, _currentPlayerData.Graveyard[1]);
        }

        [TestMethod]
        public void TalibanTest()
        {
            var cp = new CardPower
            {
                Power = _powerTaliban,
                Card = _cardB,
                PowerId = Power.TALIBAN_ID
            };

            _playableCardA.Attack = 1000;
            _playableCardA.Health = 100000;

            _playableCardB.Attack = 1;
            _playableCardB.Health = 10;

            _cardB.CardPowers.Add(cp);

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var endTurnEvent5 = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_playableCardA, _currentPlayerData.Graveyard[0]);
            Assert.AreEqual(_playableCardB, _opposingPlayerData.Graveyard[0]);
        }

        [TestMethod]
        public void RandomPainTest()
        {
            var cp = new CardPower
            {
                Power = _powerRandomPain,
                Card = _cardMagic,
            };

            _playableCardB.Health = 10;
            _playableCardC.Health = 10;

            _cardMagic.CardPowers.Add(cp);       

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);
            _opposingPlayerData.AddCardToBattleField(_playableCardC);
            _currentPlayerData.Hand.Add(_playableCardMagic);

            var playEvent = new PlayCardEvent(_currentPlayerData, _opposingPlayerData, _playableCardMagic.Id, true);

            var damage = (playEvent.Events!.Single(e => e.EventType == "RandomPain") as RandomPainEvent)!.Value;
            var index = (playEvent.Events!.Single(e => e.EventType == "RandomPain") as RandomPainEvent)!.Index;


            Assert.AreEqual(10 - damage, _opposingPlayerData.BattleField[index].Health);
            // TODO: Vérifier que la carte Spell n'est plus sur le BattleField (Graveyard)
            Assert.AreEqual(_playableCardMagic, _currentPlayerData.Graveyard[0]);
        }

    }
}
