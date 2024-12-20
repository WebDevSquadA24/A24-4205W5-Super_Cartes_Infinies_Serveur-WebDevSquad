﻿using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Tests.Services
{
    [TestClass]
    public class PowerTests : BaseTests
	{
        public PowerTests()
        {
        }

        [TestInitialize]
        public void Init()
        {
            base.Init();
        }

        [TestMethod]
        public void FirstStrikeAttacks()
        {
            Power firstStrikePower = new Power
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower
            {
                PowerId = Power.FIRST_STRIKE_ID,
                Power = firstStrikePower,
                Card = _cardA
            };

            _cardA.CardPowers = new List<CardPower> { cardPower };

            // On réduit le Health de la carte B pour que la carte meurt
            _playableCardB.Health = _playableCardA.Attack;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // La carte A n'a pas été blessé car elle a attaqué et tué son advesaire avant qu'il n'est eu
            // le temps de réagir
            Assert.AreEqual(_cardA.Health, _playableCardA.Health);
            Assert.AreEqual(0, _playableCardB.Health);
        }

        [TestMethod]
        public void FirstStrikeAttackWithoutKill()
        {
            Power firstStrikePower = new Power
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower
            {
                Power = firstStrikePower,
                Card = _cardA
            };

            _cardA.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // FirstStrike n'a aucun effet si l'attaquant ne tue pas le défenseur
            // Les deux cartes ont été blessées normalement
            Assert.AreEqual(_cardA.Health - _playableCardB.Attack, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);
        }

        [TestMethod]
        public void FirstStrikeNeSertARienPourLaDefense()
        {
            Power firstStrikePower = new Power
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower
            {
                Power = firstStrikePower,
                Card = _cardB
            };

            _cardB.CardPowers = new List<CardPower> { cardPower };

            // On réduit le Health de la carte A pour que la carte meurt
            _playableCardA.Health = _playableCardB.Attack;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // FirstStrike n'a aucun effet si il est sur le défenseur
            Assert.AreEqual(0, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);
        }

        [TestMethod]
        public void ThornsAttackSimple()
        {
            Power thornsPower = new Power
            {
                Id = Power.THORNS_ID
            };

            // On donne le pouvoir Thorn au défenseur
            CardPower cardPower = new CardPower
            {
                Power = thornsPower,
                PowerId = Power.THORNS_ID,
                Card = _cardB,
                Value = 1
            };
            _cardB.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            Assert.AreEqual(_cardA.Health - _playableCardB.Attack - cardPower.Value, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);

            AssertBothCardsStillOnBattlefield();
        }

        [TestMethod]
        public void ThornsAttackAvecDesDegatsSuffisantPourTuerAttaquant()
        {
            Power thornsPower = new Power
            {
                Id = Power.THORNS_ID
            };

            // On donne le pouvoir Thorn au défenseur
            CardPower cardPower = new CardPower
            {
                Power = thornsPower,
                Card = _cardB,
                PowerId = Power.THORNS_ID,
                // On veut être certain que l'attaquant meurt par Thorns pendant le test
                Value = _cardA.Health
            };
            _cardB.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            Assert.AreEqual(1, _opposingPlayerData.Health);
            Assert.AreEqual(1, _currentPlayerData.Health);

            // Si l'attaquant meurt par les dégâts de Thorns, il n'a pas le temps de commencer à se battre et le défenseur ne reçoit aucun dégât
            Assert.AreEqual(_cardA.Health - cardPower.Value, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health, _playableCardB.Health);

            // 
            AssertCurrentPlayerCardDied();
        }

        [TestMethod]
        public void ThornsSertARienPourUneAttaque()
        {
            Power thornsPower = new Power
            {
                Id = Power.THORNS_ID
            };

            // On donne le pouvoir Thorn a l'attaquant
            CardPower cardPower = new CardPower
            {
                Power = thornsPower,
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            // Les deux cartes ont simplement perdu les points de vues habituelles
            Assert.AreEqual(_cardA.Health - _playableCardB.Attack, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);
        }

        [TestMethod]
        public void Heal()
        {
            Power healPower = new Power
            {
                Id = Power.HEAL_ID
            };

            // On donne le pouvoir Heal à l'attaquant
            CardPower cardPower = new CardPower
            {
                PowerId = Power.HEAL_ID,
                Power = healPower,
                Card = _cardB,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            var damagedPlayableCard = new PlayableCard(_cardB)
            {
                Id = 3
            };

            // On retire 2 PVs à l'attaquant et 4 PVs à l'autre carte de l'attaquant
            _playableCardA.Health -= 2;
            damagedPlayableCard.Health -= 4;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _currentPlayerData.AddCardToBattleField(damagedPlayableCard);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // _playableCardA devrait avoir retrouvé ses points de vie initiaux            
            Assert.AreEqual(_cardA.Health - _playableCardB.Attack, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);

            // damagePlayableCard devrait avoir été guéri de 3 de ses 4 de dégâts
            Assert.AreEqual(_cardB.Health - 1, damagedPlayableCard.Health);

            // Le damagedPlayableCard tue le joueur adverse car il n'y avait pas de carte pour le protéger
            Assert.AreEqual(0, _opposingPlayerData.Health);
            Assert.AreEqual(1, _currentPlayerData.Health);

            // Toutes les cartes sont encore en jeu
            Assert.AreEqual(2, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);
            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }

        [TestMethod]
        public void Love()
        {
            Power lovePower = new Power
            {
                Id = Power.LOVE_OF_JESUS_CHRIST
            };

            // On donne le pouvoir Heal à l'attaquant
            CardPower cardPower = new CardPower
            {
                PowerId = Power.LOVE_OF_JESUS_CHRIST,
                Power = lovePower,
                Card = _cardB,
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            var playableCardOpponent = new PlayableCard(_cardB)
            {
                Id = 3
            };

            // On retire 2 PVs à l'attaquant et 4 PVs à l'autre carte de l'attaquant

            _currentPlayerData.BattleField.Add(_playableCardA);
            _currentPlayerData.BattleField.Add(playableCardOpponent);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // _playableCardA devrait avoir retrouvé ses points de vie initiaux            
            Assert.AreEqual(_cardA.Health - _playableCardB.Attack, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);

            // Le damagedPlayableCard tue le joueur adverse car il n'y avait pas de carte pour le protéger
            Assert.AreEqual(0, _opposingPlayerData.Health);

            // Le currentPlayer a un Hp de plus
            Assert.AreEqual(2, _currentPlayerData.Health);

            // Toutes les cartes sont encore en jeu
            Assert.AreEqual(2, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);
            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }


        [TestMethod]
        public void HasPowerFalse()
        {

            Assert.AreEqual(false, _playableCardTest.HasPower(1));
        }

        [TestMethod]
        public void HasPowerTrue()
        {

            Assert.AreEqual(true, _playableCardTest.HasPower(2));
        }

        [TestMethod]
        public void GetPowerValueOtherPower()
        {

            Assert.AreEqual(0, _playableCardTest.GetPowerValue(1));
        }

        [TestMethod]
        public void GetPowerValueGoodPower()
        {

            Assert.AreEqual(3, _playableCardTest.GetPowerValue(2));
        }

    }
}

