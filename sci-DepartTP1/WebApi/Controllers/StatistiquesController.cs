using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatistiquesController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public StatistiquesController(ApplicationDbContext dbContext, PlayersService playersService)
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        [HttpGet]
        public ActionResult<Player> GetStatsPlayer()
        {
            var user = _dbContext.Users.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            var player = _playersService.GetPlayerFromUserId(user.Id);

            if(player == null)
            {
                return NotFound("Player non trouvé");
            }

            return Ok(player);
        }
    }
}
