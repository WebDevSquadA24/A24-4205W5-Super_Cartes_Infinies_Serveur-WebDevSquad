using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace WebApi.Services
{
    public class DecksService
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public DecksService(ApplicationDbContext dbContext, PlayersService playersService)
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        public IEnumerable<Deck> GetPlayerDecks(string userId)
        {
            throw new NotImplementedException();
        }

        public Deck GetCurrent(string userId)
        {
            throw new NotImplementedException();
        }

        public Deck Create(string name)
        {
            throw new NotImplementedException();
        }

        public void Delete(int deckId)
        {
            throw new NotImplementedException();
        }

        public Deck Rename(int deckId, string name)
        {
            throw new NotImplementedException();
        }

        public Deck MakeCurrent(int deckId)
        {
            throw new NotImplementedException();
        }

        public Deck AddCard(int deckId, int ownedCardId)
        {
            throw new NotImplementedException();
        }

        public Deck removeCard(int deckId, int ownedCardId)
        {
            throw new NotImplementedException();
        }
    }
}
