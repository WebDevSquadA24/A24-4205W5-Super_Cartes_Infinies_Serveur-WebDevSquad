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
            .UseInMemoryDatabase(databaseName: "CardsService")
            .UseLazyLoadingProxies(true)
            .Options;
        }

        [TestInitialize]
        public void Init()
        {
            var db = new ApplicationDbContext(options);

            var players = new Player[]
            {
            new Player() { UserId = "1" },
            new Player() { UserId = "2" },
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
                new Deck() { Id = 2, Player = players[0], OwnedCards = [ownedCard[1]] },
            };
            db.AddRange(deck);

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
        public async Task CreateDeck()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            var result = await _decksService.Create("test", "1");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, db.Decks.Count());
        }

        [TestMethod]
        public async Task DeleteDeck_Ok()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            await _decksService.Delete(1, "1");
            Assert.AreEqual(0, db.Decks.Count());
        }

        [TestMethod]
        public async Task DeleteDeck_Current()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            await _decksService.MakeCurrent(1, "1");
            Assert.ThrowsException<InvalidOperationException>(async () => await _decksService.Delete(1, "1"));

            Assert.AreEqual(1, db.Decks.Count());
        }

        [TestMethod]
        public async Task DeleteDeck_NotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            var e = Assert.ThrowsException<UnauthorizedAccessException>(async () => await _decksService.Delete(1, "2"));

            Assert.AreEqual(1, db.Decks.Count());
        }

        [TestMethod]
        public async Task AddCardToDeck_Ok()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            await _decksService.AddCard(1, 1, "1");

            Assert.IsTrue(db.Decks.Single(d => d.Id == 1).OwnedCards.Contains(db.OwnedCards.Single(oc => oc.Id == 1)));
        }

        [TestMethod]
        public async Task AddCardToDeck_DeckNotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.ThrowsException<UnauthorizedAccessException>(async () => await _decksService.AddCard(1, 1, "2"));
        }

        [TestMethod]
        public async Task AddCardToDeck_CardNotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task RemoveCard_Owned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            await _decksService.RemoveCard(2, 1, "1");

            Assert.AreEqual(0, db.Decks.Single(d => d.Id == 1).OwnedCards.Count);
        }

        [TestMethod]
        public async Task RemoveCard_NotOwned()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Assert.ThrowsException<UnauthorizedAccessException>(async () => await _decksService.RemoveCard(1, 1, "2"));

            Assert.IsTrue(true);
        }
    }
}