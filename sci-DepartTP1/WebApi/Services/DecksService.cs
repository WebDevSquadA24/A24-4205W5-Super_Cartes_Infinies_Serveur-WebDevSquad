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

        public async Task<IEnumerable<Card>> GetCardsNotInDeck(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            var playerOwnedCard = player.OwnedCards;
            var deck = await GetDeck(deckId);

            var cards = new List<Card>();
            foreach (var ownedCard in playerOwnedCard)
            {
                if (!deck!.OwnedCards.Contains(ownedCard))
                    cards.Add(ownedCard.Card);
            }
            return cards;
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

        public async Task Delete(int deckId, string userId)
        {
            var deck = await GetDeck(deckId);

            if (deck!.Player.UserId != userId)
                throw new UnauthorizedAccessException("The player does not own the deck");

            if (deck.IsCurrent) 
                throw new InvalidOperationException("Cannot delete current deck");

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

        public async Task<Deck> AddCard(int deckId, int cardId, string userId)
        {
            var deck = await GetDeck(deckId);
            var player = _playersService.GetPlayerFromUserId(userId);
            var playerCardInstances = player.OwnedCards.Where(c => c.Card.Id == cardId).ToList();

            foreach (var ownedCard in deck!.OwnedCards)
            {
                playerCardInstances.Remove(ownedCard);
            }

            if (playerCardInstances.Count == 0)
                throw new InvalidOperationException("The card is already in the deck");

            var cardToAdd = playerCardInstances.First();

            if (deck!.Player != player || cardToAdd.Player != player)
                throw new UnauthorizedAccessException("The deck or the card does not belong to the player");

            deck.OwnedCards.Add(cardToAdd);
            _dbContext.Update(deck);
            await _dbContext.SaveChangesAsync();

            return deck;
        }

        public Deck removeCard(int deckId, int CardId)
        {
            throw new NotImplementedException();
        }
    }
}
