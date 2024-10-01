using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public CardsService(ApplicationDbContext dbContext, PlayersService playersService)
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        public IEnumerable<Card> GetPlayersCards(string userId)
        {
            // Stub: Pour l'intant, le stub retourne simplement les 8 premières cartes
            // L'implémentation réelle devra utiliser un service et retourner les cartes qu'un joueur possède
            // L'implémentation est la responsabilité de la personne en charge de la partie [Enregistrement et connexion]
            var player = _playersService.GetPlayerFromUserId(userId);
            return player.OwnedCards.Select(oc => oc.Card);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _dbContext.Cards;
        }
    }
}

