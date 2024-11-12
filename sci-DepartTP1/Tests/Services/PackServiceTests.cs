using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;



namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class PackServiceTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _dbContext;
        private PackService _packService;
        private Player _player;
        private Pack _packNormale;
        private Pack _packExpensive;

        [TestInitialize]
        public void Setup()
        {
            // Initialiser le contexte de base de données en mémoire
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "PackServiceTestDb")
                .UseLazyLoadingProxies(true)
                .Options;

            _dbContext = new ApplicationDbContext(_options);

            // Initialiser un joueur
            _player = new Player
            {
                UserId = "PlayerTest",
                Id = 1,
                Money = 1000,
                Name = "PlayerTestName"
            };
            _dbContext.Players.Add(_player);

            // Initialiser un pack normale
            _packNormale = new Pack
            {
                Id = 1,
                Name = "Test Pack",
                Price = 500.0,
                NbCards = 4,
                ImageURL = "https://sf2.lechasseurfrancais.com/wp-content/uploads/2023/05/rhinoceros-blanc1.jpg",
                Probabilities = new List<Probability>
                {
                    new Probability { Rarity = Rarity.Commune, BaseQty = 0, Value = 0.5 },
                    new Probability { Rarity = Rarity.Rare, BaseQty = 0, Value = 0.3 },
                    new Probability { Rarity = Rarity.Épique, BaseQty = 0, Value = 0.2 }
                },

            };

            // Initialiser un pack chère 
            _packExpensive = new Pack()
            {
                Id = 3,
                Name = "ExpensivePack",
                Price = 2000,
                NbCards = 5,
                ImageURL = "https://sf2.lechasseurfrancais.com/wp-content/uploads/2023/05/rhinoceros-blanc1.jpg",
                Probabilities = new List<Probability>
                {
                    new Probability { Rarity = Rarity.Rare, BaseQty = 0, Value = 0.65 },
                    new Probability { Rarity = Rarity.Épique, BaseQty = 1, Value = 0.25 },
                    new Probability { Rarity = Rarity.Légendaire, BaseQty = 0, Value = 0.1 }
                }
            };

            _dbContext.Packs.Add(_packNormale);
            _dbContext.Packs.Add(_packExpensive);

            // Initialiser 15 cartes
            var cards = new List<Card>
            {
                new Card { Id = 1, Name = "Commune Card 1", Rarity = Rarity.Commune },
                new Card { Id = 2, Name = "Commune Card 2", Rarity = Rarity.Commune },
                new Card { Id = 3, Name = "Commune Card 3", Rarity = Rarity.Commune },
                new Card { Id = 4, Name = "Commune Card 4", Rarity = Rarity.Commune },
                new Card { Id = 5, Name = "Commune Card 5", Rarity = Rarity.Commune },
                new Card { Id = 6, Name = "Rare Card 1", Rarity = Rarity.Rare },
                new Card { Id = 7, Name = "Rare Card 2", Rarity = Rarity.Rare },
                new Card { Id = 8, Name = "Rare Card 3", Rarity = Rarity.Rare },
                new Card { Id = 9, Name = "Rare Card 4", Rarity = Rarity.Rare },
                new Card { Id = 10, Name = "Épique Card 1", Rarity = Rarity.Épique },
                new Card { Id = 11, Name = "Épique Card 2", Rarity = Rarity.Épique },
                new Card { Id = 12, Name = "Épique Card 3", Rarity = Rarity.Épique },
                new Card { Id = 13, Name = "Légendaire Card 1", Rarity = Rarity.Légendaire },
                new Card { Id = 14, Name = "Légendaire Card 2", Rarity = Rarity.Légendaire },
                new Card { Id = 15, Name = "Légendaire Card 3", Rarity = Rarity.Légendaire }
            };
            _dbContext.Cards.AddRange(cards);

            // Initialiser 15 OwnedCards pour le joueur
            var ownedCards = new List<OwnedCard>
            {
                new OwnedCard { Player = _player, Card = cards[0] },
                new OwnedCard { Player = _player, Card = cards[1] },
                new OwnedCard { Player = _player, Card = cards[2] },
                new OwnedCard { Player = _player, Card = cards[3] },
                new OwnedCard { Player = _player, Card = cards[4] },
                new OwnedCard { Player = _player, Card = cards[5] },
                new OwnedCard { Player = _player, Card = cards[6] },
                new OwnedCard { Player = _player, Card = cards[7] },
                new OwnedCard { Player = _player, Card = cards[8] },
                new OwnedCard { Player = _player, Card = cards[9] },
                new OwnedCard { Player = _player, Card = cards[10] },
                new OwnedCard { Player = _player, Card = cards[11] },
                new OwnedCard { Player = _player, Card = cards[12] },
                new OwnedCard { Player = _player, Card = cards[13] },
                new OwnedCard { Player = _player, Card = cards[14] }
            };
            _dbContext.OwnedCards.AddRange(ownedCards);

            // Enregistrer toutes les modifications
            _dbContext.SaveChanges();

            // Initialiser le PackService
            _packService = new PackService(_dbContext, null);
        }


        [TestCleanup]
        public void Dispose()
        {
            // Suppression des données de test dans chaque table
            _dbContext.Players.RemoveRange(_dbContext.Players);
            _dbContext.Cards.RemoveRange(_dbContext.Cards);
            _dbContext.Packs.RemoveRange(_dbContext.Packs);
            _dbContext.OwnedCards.RemoveRange(_dbContext.OwnedCards);
            _dbContext.CardPowers.RemoveRange(_dbContext.CardPowers);
            _dbContext.StarterCards.RemoveRange(_dbContext.StarterCards);
            _dbContext.GameConfigs.RemoveRange(_dbContext.GameConfigs);
            
            // Sauvegarde des modifications pour confirmer la suppression
            _dbContext.SaveChanges();

            // Libération des ressources
            _dbContext.Dispose();
        }


        [TestMethod()]
        public async Task VerifyPackPurchaseCardCountAndMoneySpent()
        {
            var playerMoneyBeforeBye = _player.Money;
            var playerOwnedCardsBeforeBye = _player.OwnedCards.Count;

            var purchaseResult = await _packService.OpenPack(_packNormale, _player);

            var playerMoneyAfterBye = playerMoneyBeforeBye - _packNormale.Price;
            var playerOwnedCardsAfterBye = playerOwnedCardsBeforeBye + _packNormale.NbCards;

            Assert.AreEqual(_packNormale.NbCards, purchaseResult.Count);
            Assert.AreEqual(playerMoneyAfterBye, _player.Money);
            Assert.AreEqual(playerOwnedCardsAfterBye, _player.OwnedCards.Count);
        }

        [TestMethod()]
        public async Task VerifyPackPurchaseFailsWhenNotEnoughMoney()
        {
            var playerMoneyBeforeBye = _player.Money;

            var purchaseResult = await _packService.OpenPack(_packExpensive, _player);

            Assert.AreEqual(playerMoneyBeforeBye, _player.Money);
            Assert.IsNull(purchaseResult);
        }


        [TestMethod()]
        public async Task VerifyCardsAreNotCommonAndAtLeastOneEpicInExpensivePack()
        {
            _player.Money = 2000.0;
            _dbContext.SaveChanges();

            var purchaseResult = await _packService.OpenPack(_packExpensive, _player);

            Assert.IsFalse(purchaseResult.Any(card => card.Rarity == Rarity.Commune));
            Assert.IsTrue(purchaseResult.Any(card => card.Rarity == Rarity.Épique));
        }

    }
}