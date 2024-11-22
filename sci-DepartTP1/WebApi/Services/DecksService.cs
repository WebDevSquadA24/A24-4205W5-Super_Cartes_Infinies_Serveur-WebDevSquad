using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private IPlayersService _playersService;

        public DecksService(ApplicationDbContext dbContext, IPlayersService playersService)
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        public IEnumerable<Deck> GetDecks(string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            return player.Decks;
        }

        public Deck? GetDeck(int deckId)
        {
            return _dbContext.Decks.Find(deckId);
        }

        public IEnumerable<Card>? GetCardsNotInDeck(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            var deck = GetDeck(deckId);

            if (deck == null) return null;

            return player.OwnedCards.Except(deck.OwnedCards).Select(oc => oc.Card);
        }

        public Deck GetCurrent(string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);
            return player.Decks.Find(d => d.IsCurrent)!;
        }

        public Deck Create(string name, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var x = _dbContext.GameConfigs.First().NbMaxDeck;

            if (player.Decks.Count >= x)
                throw new InvalidOperationException();

            var deck = new Deck()
            {
                Name = name,
                IsCurrent = false,
                Player = player,
            };

            _dbContext.Add(deck);
            _dbContext.SaveChanges();

            return deck;
        }

        public void Delete(int deckId, string userId)
        {
            var deck = GetDeck(deckId);

            if (deck!.Player.UserId != userId)
                throw new UnauthorizedAccessException();

            if (deck.IsCurrent) 
                throw new InvalidOperationException();

            deck.OwnedCards.Clear();

            _dbContext.Remove(deck);
            _dbContext.SaveChanges();
        }

        public Deck? MakeCurrent(int deckId, string userId)
        {
            var player = _playersService.GetPlayerFromUserId(userId);

            var oldCurrentDeck = player.Decks.Find(d => d.IsCurrent);
            var newCurrentDeck = player.Decks.Find(d => d.Id == deckId);

            if (oldCurrentDeck == null || newCurrentDeck == null) return null;

            oldCurrentDeck.IsCurrent = false;
            newCurrentDeck.IsCurrent = true;

            _dbContext.Update(oldCurrentDeck);
            _dbContext.Update(newCurrentDeck);

            _dbContext.SaveChanges();

            return newCurrentDeck;
        }

        public Deck? AddCard(int deckId, int cardId, string userId)
        {
            var deck = GetDeck(deckId);
            var player = _playersService.GetPlayerFromUserId(userId);

            if (deck == null) return null;
            if (deck.OwnedCards.Count >= _dbContext.GameConfigs.First().NbMaxCard)
                throw new InvalidOperationException();

            var cardToAdd = player.OwnedCards.Where(oc => oc.Card.Id == cardId).Except(deck.OwnedCards).First();

            if (deck.Player.Id != player.Id)
                throw new UnauthorizedAccessException();

            deck.OwnedCards.Add(cardToAdd);
            _dbContext.Update(deck);
            _dbContext.SaveChanges();

            return deck;
        }

        public Deck RemoveCard(int deckId, int cardId, string userId)
        {
            var deck = GetDeck(deckId);
            var player = _playersService.GetPlayerFromUserId(userId);
            var cardToRemove = deck!.OwnedCards.Where(c => c.Card.Id == cardId).First();

            if (deck!.Player.Id != player.Id || cardToRemove.Player.Id != player.Id)
                throw new UnauthorizedAccessException();

            deck.OwnedCards.Remove(cardToRemove);
            _dbContext.Update(deck);
            _dbContext.SaveChanges();

            return deck;
        }
    }
}
