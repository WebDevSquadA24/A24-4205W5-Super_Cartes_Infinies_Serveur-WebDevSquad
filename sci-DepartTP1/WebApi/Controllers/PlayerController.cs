using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public PlayerController(ApplicationDbContext dbContext, PlayersService playersService) 
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        [HttpGet("{playerId}")]
        public ActionResult<Player> GetPlayerData(int playerId)
        {
            var playerData = _dbContext.Players.FirstOrDefault(x => x.Id == playerId);

            if (playerData == null)
                return NotFound("Player not found");
            return Ok(playerData);
        }
    }
}
