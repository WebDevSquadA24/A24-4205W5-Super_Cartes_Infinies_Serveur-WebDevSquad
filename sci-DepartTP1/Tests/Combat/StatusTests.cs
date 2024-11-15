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
                Card = _cardTest,
            };

            _cardA.CardPowers.Add(cp);

            var healthB = _playableCardB.Health;
            var attackB = _playableCardB.Attack;

            var healthC = _playableCardB.Health;
            var attackC = _playableCardB.Attack;


            _currentPlayerData.AddCardToBattleField(_playableCardB);
            _opposingPlayerData.AddCardToBattleField(_playableCardC);

            var playCard = new PlayCardEvent(_currentPlayerData, _opposingPlayerData, _playableCardA.Id, true);


            Assert.AreEqual(healthB, _playableCardB.Attack);
            Assert.AreEqual(attackB, _playableCardB.Health);

            Assert.AreEqual(healthC, _playableCardC.Attack);
            Assert.AreEqual(attackC, _playableCardC.Health);
        }

        
    }
}
