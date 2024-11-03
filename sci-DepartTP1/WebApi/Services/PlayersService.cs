using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class PlayersService
    {
        private ApplicationDbContext _dbContext;
        private StartingCardsService _startingCardsService;

        public PlayersService(ApplicationDbContext context, StartingCardsService startingCardsService)
        {
            _dbContext = context;
            _startingCardsService = startingCardsService;
        }

        public Player CreatePlayer(IdentityUser user)
        {
            var gameConfig = _dbContext.GameConfigs.FirstOrDefault();
            
            Player p = new Player()
            {
                Id = 0,
                UserId = user.Id,
                Name = user.Email!,
                User = user,
                Money = gameConfig.BeginnerMoney,
            };

            // TODO: Utilisez le service StartingCardsService pour obtenir les cartes de départ
            // TODO: Ajoutez ces cartes au joueur en utilisant le modèle OwnedCard que vous allez devoir ajouter
            List<OwnedCard> startingCards = _startingCardsService.GetStartingCards().Select(c => new OwnedCard()
            {
                Id = 0,
                Player = p,
                Card = c,
            }).ToList();

            _dbContext.Add(p);
            _dbContext.AddRange(startingCards);
            _dbContext.SaveChanges();

            return p;
        }

        public virtual Player GetPlayerFromUserId(string userId)
        {
            return _dbContext.Players.Single(p => p.UserId == userId);
        }

        public Player GetPlayerFromUserName(string userName)
        {
            return _dbContext.Players.Single(p => p.User!.UserName == userName);
        }
    }
}

