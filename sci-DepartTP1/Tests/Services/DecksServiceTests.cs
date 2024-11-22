using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Super_Cartes_Infinies.Models;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Moq;
using Super_Cartes_Infinies.Services;
using Microsoft.Extensions.Options;

namespace WebApi.Services.Tests
{
    [TestClass]
    public class DecksServiceTests
    {
        private ApplicationDbContext _db;
        private Mock<IPlayersService> _mockPlayersService;
        private DecksService _decksService;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: $"DecksService_{Guid.NewGuid()}")
            .UseLazyLoadingProxies(true)
            .EnableSensitiveDataLogging()
            .Options;

            _db = new ApplicationDbContext(options);

            var players = new Player[]
            {
            new Player() { Id = 1, UserId = "1" },
            new Player() { Id = 2, UserId = "2" },
            };
            _db.AddRange(players);

            var card = new Card() { Id = 1 };
            _db.Add(card);

            var ownedCard = new OwnedCard[]
            {
                 new OwnedCard { Id = 1, Player = players[0], Card = card },
                 new OwnedCard { Id = 2, Player = players[1], Card = card },
            };
            _db.AddRange(ownedCard);

            var deck = new Deck[]
            {
                new Deck() { Id = 1, Player = players[0] },
                new Deck() { Id = 2, Player = players[0], OwnedCards = [ownedCard[0]], IsCurrent = true },
            };
            _db.AddRange(deck);

            var gameConfig = new GameConfig()
            {
                Id = 1,
                NbMaxDeck = 10,
                NbMaxCard = 10
            };
            _db.Add(gameConfig);

            _db.SaveChanges();

            _mockPlayersService = new Mock<IPlayersService>();
            _mockPlayersService.Setup(x => x.GetPlayerFromUserId("1"))
                .Returns(_db.Players.Where(p => p.UserId == "1").First());
            _mockPlayersService.Setup(x => x.GetPlayerFromUserId("2"))
                .Returns(_db.Players.Where(p => p.UserId == "2").First());

            _decksService = new DecksService(_db, _mockPlayersService.Object);
        }

        [TestCleanup]
        public void Dispose()
        {
            _db.Dispose();
        }

        [TestMethod]
        public void CreateDeck()
        {
            var result = _decksService.Create("test", "1");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, _db.Decks.Count());
        }

        [TestMethod]
        public void DeleteDeck_Ok()
        {
            _decksService.Delete(1, "1");

            Assert.AreEqual(1, _db.Decks.Count());
        }

        [TestMethod]
        public void DeleteDeck_Current()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _decksService.Delete(2, "1"));

            Assert.AreEqual(2, _db.Decks.Count());
        }

        [TestMethod]
        public void DeleteDeck_NotOwned()
        {
            Assert.ThrowsException<UnauthorizedAccessException>(() => _decksService.Delete(1, "2"));

            Assert.AreEqual(2, _db.Decks.Count());
        }

        [TestMethod]
        public void AddCardToDeck_Ok()
        {
            _decksService.AddCard(1, 1, "1");

            Assert.IsTrue(_db.Decks.Single(d => d.Id == 1).OwnedCards.Contains(_db.OwnedCards.Single(oc => oc.Id == 1)));
        }

        [TestMethod]
        public void AddCardToDeck_DeckNotOwned()
        {
            Assert.ThrowsException<UnauthorizedAccessException>(() => _decksService.AddCard(1, 1, "2"));
        }

        [TestMethod]
        public void RemoveCard_Owned()
        {
            _decksService.RemoveCard(2, 1, "1");

            Assert.AreEqual(0, _db.Decks.Single(d => d.Id == 2).OwnedCards.Count);
        }

        [TestMethod]
        public void RemoveCard_NotOwned()
        {
            Assert.ThrowsException<UnauthorizedAccessException>(() => _decksService.RemoveCard(2, 1, "2"));

            Assert.IsTrue(true);
        }
    }
}