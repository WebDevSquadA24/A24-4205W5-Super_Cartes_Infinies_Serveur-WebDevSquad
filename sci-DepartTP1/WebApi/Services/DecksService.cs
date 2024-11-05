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

        public IEnumerable<Deck> GetDecks(string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            return player.Decks;
        }

        public async Task<Deck?> GetDeck(int deckId)
        {

            return await _dbContext.Decks.FindAsync(deckId);
        }

        public Deck GetCurrent(string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            return player.Decks.Find(d => d.IsCurrent)!;
        }

        public async Task<Deck> Create(string name, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var deck = new Deck()
            {
                Id = 0,
                Name = name,
                IsCurrent = false,
                Player = player,
            };

            await _dbContext.AddAsync(deck);
            await _dbContext.SaveChangesAsync();

            return deck;
        }

        public async Task Delete(Deck deck, string userId)
        {
            if (deck.Player.UserId != userId)
                throw new UnauthorizedAccessException("The player doesn't own the deck");

            if (deck.IsCurrent) throw new InvalidOperationException("Cannot delete current deck");

            _dbContext.Remove(deck);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Deck> MakeCurrent(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var oldCurrentDeck = player.Decks.Find(d => d.IsCurrent);
            var newCurrentDeck = player.Decks.Find(d => d.Id == deckId);

            oldCurrentDeck!.IsCurrent = false;
            newCurrentDeck!.IsCurrent = true;

            _dbContext.Update(oldCurrentDeck);
            _dbContext.Update(newCurrentDeck);

            await _dbContext.SaveChangesAsync();

            return newCurrentDeck;
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
