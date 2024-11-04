using Microsoft.AspNetCore.Http.HttpResults;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace WebApi.Services
{
    public class DecksService
    {
        private ApplicationDbContext _dbContext;

        public DecksService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Deck> GetPlayerDecks(string userId)
        {
            return _dbContext.Decks.Where(d => d.OwnedCards.FirstOrDefault()!.Player.UserId == userId);
        }

        public IEnumerable<OwnedCard> GetDeckOwnedCards(int deckId)
        {
            var deck = _dbContext.Decks.Where(d => d.Id == deckId).Single();

            return deck.OwnedCards;
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
