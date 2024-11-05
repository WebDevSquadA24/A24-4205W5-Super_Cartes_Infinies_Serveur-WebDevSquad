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

        //public async Task<List<Card>> OpenPack (Pack pack)
        //{
        //    var cards = new List<Card>();
            
        //    return cards;
        //}
    }
}
