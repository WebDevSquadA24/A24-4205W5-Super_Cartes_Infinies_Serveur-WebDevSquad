using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

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

        public async Task<IEnumerable<Card>?> GetCardsNotInDeck(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            var deck = await GetDeck(deckId);

            if (deck == null) return null;

            return player.OwnedCards.Except(deck.OwnedCards).Select(oc => oc.Card);
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
                Name = name,
                IsCurrent = false,
                Player = player,
            };

            await _dbContext.AddAsync(deck);
            await _dbContext.SaveChangesAsync();

            return deck;
        }

        public async Task Delete(int deckId, string userId)
        {
            var deck = await GetDeck(deckId);

            if (deck!.Player.UserId != userId)
                throw new UnauthorizedAccessException();

            if (deck.IsCurrent) 
                throw new InvalidOperationException();

            _dbContext.Remove(deck);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Deck?> MakeCurrent(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var oldCurrentDeck = player.Decks.Find(d => d.IsCurrent);
            var newCurrentDeck = player.Decks.Find(d => d.Id == deckId);

            if (oldCurrentDeck == null || newCurrentDeck == null) return null;

            oldCurrentDeck.IsCurrent = false;
            newCurrentDeck.IsCurrent = true;

            _dbContext.Update(oldCurrentDeck);
            _dbContext.Update(newCurrentDeck);

            await _dbContext.SaveChangesAsync();

            return newCurrentDeck;
        }

        public async Task<Deck?> AddCard(int deckId, int cardId, string userId)
        {
            var deck = await GetDeck(deckId);
            var player = _playersService.GetPlayerFromUserId(userId);

            if (deck == null) return null;

            var cardToAdd = player.OwnedCards.Where(oc => oc.Card.Id == cardId).Except(deck.OwnedCards).First();

            if (deck!.Player != player || cardToAdd.Player != player)
                throw new UnauthorizedAccessException();

            deck.OwnedCards.Add(cardToAdd);
            _dbContext.Update(deck);
            await _dbContext.SaveChangesAsync();

            return deck;
        }

        public async Task<Deck> RemoveCard(int deckId, int cardId, string userId)
        {
            var deck = await GetDeck(deckId);
            var player = _playersService.GetPlayerFromUserId(userId);
            var cardToRemove = deck!.OwnedCards.Where(c => c.Card.Id == cardId).First();

            if (deck!.Player != player || cardToRemove.Player != player)
                throw new UnauthorizedAccessException();

            deck.OwnedCards.Remove(cardToRemove);
            _dbContext.Update(deck);
            await _dbContext.SaveChangesAsync();

            return deck;
        }
    }
}
