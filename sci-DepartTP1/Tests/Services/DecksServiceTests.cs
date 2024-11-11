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

namespace WebApi.Services.Tests
{
    [TestClass]
    public class DecksServiceTests
    {
        DbContextOptions<ApplicationDbContext> options;
        private Mock<PlayersService> _mockPlayersService;
        private DecksService _decksService;

        public DecksServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: $"DecksService_{Guid.NewGuid()}")
            .UseLazyLoadingProxies(true)
            .Options;
        }

        [TestInitialize]
        public void Init()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            var players = new Player[]
            {
            new Player() { Id = 1, UserId = "1" },
            new Player() { Id = 2, UserId = "2" },
            };
            db.AddRange(players);

            var card = new Card() { Id = 1 };
            db.Add(card);

            var ownedCard = new OwnedCard[]
            {
                 new OwnedCard { Id = 1, Player = players[0], Card = card },
                 new OwnedCard { Id = 2, Player = players[1], Card = card },
            };
            db.AddRange(ownedCard);

            var deck = new Deck[]
            {
                new Deck() { Id = 1, Player = players[0] },
                new Deck() { Id = 2, Player = players[0], OwnedCards = [ownedCard[0]], IsCurrent = true },
            };
            db.AddRange(deck);

            var gameConfig = new GameConfig()
            {
                Id = 1,
                NbMaxDeck = 10,
                NbMaxCard = 10
            };
            db.Add(gameConfig);

            db.SaveChanges();

            _mockPlayersService = new Mock<PlayersService>(null, null);
            _mockPlayersService.Setup(x => x.GetPlayerFromUserId("1"))
                .Returns(db.Players.Single(p => p.UserId == "1"));
            _mockPlayersService.Setup(x => x.GetPlayerFromUserId("2"))
                .Returns(db.Players.Single(p => p.UserId == "2"));

            _decksService = new DecksService(new ApplicationDbContext(options), _mockPlayersService.Object);
        }

        [TestCleanup]
        public void Dispose()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.OwnedCards.RemoveRange(db.OwnedCards);
            db.Decks.RemoveRange(db.Decks);
            db.Players.RemoveRange(db.Players);
            db.Cards.RemoveRange(db.Cards);
            db.SaveChanges();


        }

        [TestMethod]
        public void CreateDeck()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            var result = _decksService.Create("test", "1");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, db.Decks.Count());
        }

        [TestMethod]
        public void DeleteDeck_Ok()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            _decksService.Delete(1, "1");

            Assert.AreEqual(1, db.Decks.Count());
        }

        [TestMethod]
        public void DeleteDeck_Current()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.ThrowsException<InvalidOperationException>(() => _decksService.Delete(2, "1"));

            Assert.AreEqual(2, db.Decks.Count());
        }

        [TestMethod]
        public void DeleteDeck_NotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.ThrowsException<UnauthorizedAccessException>(() => _decksService.Delete(1, "2"));

            Assert.AreEqual(2, db.Decks.Count());
        }

        [TestMethod]
        public void AddCardToDeck_Ok()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            _decksService.AddCard(1, 1, "1");

            Assert.IsTrue(db.Decks.Single(d => d.Id == 1).OwnedCards.Contains(db.OwnedCards.Single(oc => oc.Id == 1)));
        }

        [TestMethod]
        public void AddCardToDeck_DeckNotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.ThrowsException<UnauthorizedAccessException>(() => _decksService.AddCard(1, 1, "2"));
        }

        [TestMethod]
        public void RemoveCard_Owned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            _decksService.RemoveCard(2, 1, "1");

            Assert.AreEqual(0, db.Decks.Single(d => d.Id == 2).OwnedCards.Count);
        }

        [TestMethod]
        public void RemoveCard_NotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.ThrowsException<UnauthorizedAccessException>(() => _decksService.RemoveCard(2, 1, "2"));

            Assert.IsTrue(true);
        }
    }
}