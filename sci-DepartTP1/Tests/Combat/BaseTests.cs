using Microsoft.AspNetCore.Identity;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Tests.Services
{
    public class BaseTests
	{
        protected const int STARTING_PLAYER_HEALTH = 1;
        protected const int NB_MANA_PER_TURN = 3;

        protected MatchPlayerData _currentPlayerData, _opposingPlayerData;
        protected Match _match;
        protected Card _cardA, _cardB, _cardC;
        protected PlayableCard _playableCardA, _playableCardB, _playableCardC, _playableCardTest;


        protected Power _powerHeal, _powerThorn, _powerFStrike, _powerChaos, _powerPoison, _powerStun, _powerEarthquake, _powerRandomPain;

        protected Card _cardTest;

        public BaseTests()
        {
        }

        protected void Init()
        {


            List<CardPower> cardP = new List<CardPower>();

            _powerFStrike = new Power()
            {
                Id = 1,
            };

            _powerHeal = new Power()
            {
                Id = 2,
            };

            _powerThorn = new Power()
            {
                Id = 3,
            };

            _powerChaos = new Power()
            {
                Id = Power.CHAOS_ID,
            };

            _powerPoison = new Power()
            {
                Id = Power.POISON_ID,
            };

            _powerStun = new Power()
            {
                Id = Power.STUN_ID,
            };

            _powerEarthquake = new Power()
            {
                Id = Power.EARTHQUAKE_ID,
            };

            _powerRandomPain = new Power()
            {
                Id = Power.RANDOM_PAIN_ID,
            };

            CardPower cardPowerTest = new CardPower()
            {
                Id = 1,
                Card = _cardTest,
                PowerId = _powerHeal.Id,
                Value = 3
            };

            cardP.Add(cardPowerTest);

            _cardTest = new Card
            {
                Id = 442,
                Attack = 1,
                Health = 5,
                Cost = 1,
                CardPowers = cardP
            };

            _playableCardTest = new PlayableCard(_cardTest)
            {
                Id = 32
            };



            Player currentPlayer = new Player()
            {
                UserId = "1"
            };
            _currentPlayerData = new MatchPlayerData(1)
            {
                Health = STARTING_PLAYER_HEALTH,
                Player = currentPlayer,
                Mana = 2
            };

            Player opposingPlayer = new Player()
            {
                UserId = "2"
            };
            _opposingPlayerData = new MatchPlayerData(2)
            {
                Health = STARTING_PLAYER_HEALTH,
                Player = opposingPlayer,
                Mana = 0
            };




            // Le match n'est pas utilisé par ce test, on peut simplement en créer un sans initializer les données
            _match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = _currentPlayerData,
                PlayerDataB = _opposingPlayerData,
                GameConfig = new GameConfig()
            };

            _cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Health = 3,
                Cost = 1
            };

            _cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Health = 5,
                Cost = 1,
            };

            _cardC = new Card
            {
                Id = 44,
                Attack = 1,
                Health = 5,
                Cost = 1,
            };

            _playableCardA = new PlayableCard(_cardA)
            {
                Id = 1
            };
            _playableCardB = new PlayableCard(_cardB)
            {
                Id = 2
            };

            _playableCardC = new PlayableCard(_cardC)
            {
                Id = 2
            };


        }

        protected void AssertBothCardsStillOnBattlefield()
        {
            Assert.AreEqual(1, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);

            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }

        protected void AssertCurrentPlayerCardDied()
        {
            Assert.AreEqual(0, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(1, _currentPlayerData.Graveyard.Count);

            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }

        protected void AssertOpposingPlayerCardDied()
        {
            Assert.AreEqual(1, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);

            Assert.AreEqual(0, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(1, _opposingPlayerData.Graveyard.Count);
        }

        protected void AssertBothPlayersStillHaveFullHealth()
        {
            Assert.AreEqual(STARTING_PLAYER_HEALTH, _opposingPlayerData.Health);
            Assert.AreEqual(STARTING_PLAYER_HEALTH, _currentPlayerData.Health);
        }

        
    }
}

