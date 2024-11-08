using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;



namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class PackServiceTests
    {
        private ApplicationDbContext _dbContext;
        private PackService _packService;
        private Player _player;

        DbContextOptions<ApplicationDbContext> options;

        public PackServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "PackService")
                            .UseLazyLoadingProxies(true)
                            .Options;
        }

        [TestMethod()]
        public async Task VerifyPackPurchaseCardCountAndMoneySpent()
        {
            _dbContext = new ApplicationDbContext(options);

            _player = new Player
            {
                UserId = "PlayerTest",
                Id = 1,
                Money = 1000,
                Name = "PlayerTestName",
            };

            _packService = new PackService(_dbContext, null);

            Pack packTest = new Pack()
            {
                Id = 1,
                Name = "PackTest",
                DefaultRarity = Rarity.Commune,
                NbCards = 3,
                Price = 100,
                ImageURL = "https://sf2.lechasseurfrancais.com/wp-content/uploads/2023/05/rhinoceros-blanc1.jpg",
                Probabilities = new List<Probability>
                {
                    new Probability { Rarity = Rarity.Commune, BaseQty = 0, Value = 0.5 },
                    new Probability { Rarity = Rarity.Rare, BaseQty = 0, Value = 0.3 },
                    new Probability { Rarity = Rarity.Épique, BaseQty = 0, Value = 0.2 }
                }
            };

            double playerMoneyBeforeBye = _player.Money;

            var cards = await _packService.OpenPack(packTest, _player);

            Assert.AreEqual(packTest.NbCards, cards.Count);
            Assert.AreEqual(playerMoneyBeforeBye - packTest.Price, _player.Money);
        }

        [TestMethod()]
        public async Task VerifyPackPurchaseFailsWhenNotEnoughMoney()
        {
            _dbContext = new ApplicationDbContext(options);

            _player = new Player
            {
                UserId = "PlayerTest",
                Id = 1,
                Money = 100,
                Name = "PlayerTestName",
            };

            _packService = new PackService(_dbContext, null);

            Pack packTest = new Pack()
            {
                Id = 1,
                Name = "PackTest",
                DefaultRarity = Rarity.Commune,
                NbCards = 3,
                Price = 500,
                ImageURL = "https://sf2.lechasseurfrancais.com/wp-content/uploads/2023/05/rhinoceros-blanc1.jpg",
                Probabilities = new List<Probability>
                {
                    new Probability { Rarity = Rarity.Commune, BaseQty = 0, Value = 0.5 },
                    new Probability { Rarity = Rarity.Rare, BaseQty = 0, Value = 0.3 },
                    new Probability { Rarity = Rarity.Épique, BaseQty = 0, Value = 0.2 }
                }
            };

            double playerMoneyBeforeBye = _player.Money;

            var cards = await _packService.OpenPack(packTest, _player);

            Assert.AreEqual(playerMoneyBeforeBye, _player.Money);
        }


        [TestMethod()]
        public async Task VerifyCardsAreNotCommonAndAtLeastOneEpicInExpensivePack()
        {
            _dbContext = new ApplicationDbContext(options);
            _player = new Player
            {
                UserId = "PlayerTest",
                Id = 1,
                Money = 2000,
                Name = "PlayerTestName",
            };

            _packService = new PackService(_dbContext, null);

            var cardsInDb = new List<Card>
            {
                new Card { Id = 1, Rarity = Rarity.Commune, Name = "Common Card" },
                new Card { Id = 2, Rarity = Rarity.Rare, Name = "Rare Card" },
                new Card { Id = 3, Rarity = Rarity.Épique, Name = "Epic Card" },
                new Card { Id = 4, Rarity = Rarity.Légendaire, Name = "Legendary Card" },
            };

            _dbContext.Cards.AddRange(cardsInDb);

            Pack expensivePack = new Pack()
            {
                Id = 2,
                Name = "ExpensivePack",
                DefaultRarity = Rarity.Rare,
                NbCards = 5,
                Price = 2000,
                ImageURL = "https://sf2.lechasseurfrancais.com/wp-content/uploads/2023/05/rhinoceros-blanc1.jpg",
                Probabilities = new List<Probability>
        {
            new Probability { Rarity = Rarity.Rare, BaseQty = 0, Value = 0.65 },
            new Probability { Rarity = Rarity.Épique, BaseQty = 1, Value = 0.25 },
            new Probability { Rarity = Rarity.Légendaire, BaseQty = 0, Value = 0.1 }
        }
            };

            var cards = await _packService.OpenPack(expensivePack, _player);

            Assert.IsFalse(cards.Any(card => card.Rarity == Rarity.Commune));


            Assert.IsTrue(cards.Any(card => card.Rarity == Rarity.Épique));
        }

    }
}