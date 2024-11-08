using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;



namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class PackServiceTests
    {

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

        [TestInitialize]
        public void Init()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            _player = new Player
            {
                UserId = "PlayerTest",
                Id = 1,
                Money = 1000,
                Name = "PlayerTestName",
            };

            _packService = new PackService(null, null);
        }


        [TestMethod()]
        public async Task PackTestBonNombreDeCartes()
        {
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

            var cards = await _packService.OpenPack(packTest, _player);

            Assert.AreEqual(packTest.NbCards, cards);

        }


    }
}