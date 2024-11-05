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
        private PlayersService _playersService;

        public DecksService(ApplicationDbContext dbContext, PlayersService playersService)
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        public IEnumerable<Deck> GetPlayerDecks(string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            return player.Decks;
                //_dbContext.Decks.Where(d => d.OwnedCards.FirstOrDefault()!.Player.UserId == userId);
        }

        public IEnumerable<OwnedCard> GetDeckOwnedCards(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var deck = player.Decks.Where(d => d.Id == deckId).Single();

            return deck.OwnedCards;
        }

        public Deck GetCurrent(string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            return player.Decks.Find(d => d.IsCurrent)!;
        }

        public Deck Create(string name, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var deck = new Deck()
            {
                Id = 0,
                Name = name,
                IsCurrent = false,
                Player = player,
            };

            _dbContext.Add(deck);
            _dbContext.SaveChanges();

            return deck;
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
