using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class PackService
    {
        private ApplicationDbContext _dbContext;
        private Random _random;

        public PackService (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _random = new Random();
        }

        public IEnumerable<Pack> GetAllPacks()
        {
            return _dbContext.Packs;
        }

        public async Task<List<Card>> OpenPack(Pack pack)
        {
            var cards = new List<Card>();

            var rarities = GenerateRarities(pack.NbCards, pack.DefaultRarity, pack.Probabilities);

            foreach (var rarity in rarities)
            {
                var card = GetRandomCardByRarity(rarity);
                cards.Add(card);
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
                if (probability.Value < x)
                    return probability.Rarity;
                else
                    x -= probability.Value;
            }
            return null;
        }

        private Card GetRandomCardByRarity(Rarity rarity)
        {
            var cardsByRarity = _dbContext.Cards.Where(c => c.Rarity == rarity).ToList();
            if (cardsByRarity.Any())
            {
                return cardsByRarity[_random.Next(cardsByRarity.Count)];
            }
            return null;
        }
    }
}
