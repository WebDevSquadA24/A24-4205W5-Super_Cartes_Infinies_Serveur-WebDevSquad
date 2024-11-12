using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using System.Security.Claims;

namespace Super_Cartes_Infinies.Services
{
    public class PackService
    {
        private ApplicationDbContext _dbContext;
        private Random _random;
        private PlayersService _playersService;


        public PackService (ApplicationDbContext dbContext, PlayersService playersService)
        {
            _dbContext = dbContext;
            _random = new Random();
            _playersService = playersService;
        }

        public IEnumerable<Pack> GetAllPacks()
        {
            return _dbContext.Packs;
        }

        public async Task<List<Card>> OpenPack(Pack pack, Player player)
        {
            var cards = new List<Card>();

            var playerData = player;

            if (playerData.Money < pack.Price)
            {
                return null;
            }

            playerData.Money -= pack.Price;

            await _dbContext.SaveChangesAsync();

            var rarities = GenerateRarities(pack.NbCards, pack.DefaultRarity, pack.Probabilities);

            foreach (var rarity in rarities)
            {
                var card = GetRandomCardByRarity(rarity);
                if (card != null)
                {
                    var ownedCard = new OwnedCard
                    {
                        Card = card,
                        Player = playerData
                    };
                    cards.Add(card);
                    playerData.OwnedCards.Add(ownedCard);
                    await _dbContext.SaveChangesAsync();
                }
            }


            return cards;
        }

        private List<Rarity> GenerateRarities(int nbCards, Rarity defaultRarity, List<Probability> probabilities)
        {
            var rarities = new List<Rarity>();

            foreach (var probability in probabilities)
            {
                for (int i = 0; i < probability.BaseQty; i++)
                {
                    rarities.Add(probability.Rarity);
                }
            }

            while (rarities.Count < nbCards)
            {
                var rarity = GetRandomRarity(probabilities);
                if (rarity == null)
                {
                    rarities.Add(defaultRarity);
                }
                else
                {
                    rarities.Add(rarity.Value);
                }
            }

            return rarities;
        }

        private Rarity? GetRandomRarity(List<Probability> probabilities)
        {
            double x = _random.NextDouble();
            foreach (var probability in probabilities)
            {
                if (probability.Value > x)
                    return probability.Rarity;
                else
                    x -= probability.Value;
            }
            return null;
        }

        private Card GetRandomCardByRarity(Rarity rarity)
        {
            var card = _dbContext.Cards.Where(c => c.Rarity == rarity).OrderBy(c => Guid.NewGuid()).FirstOrDefault();
            return card;
        }
    }
}
