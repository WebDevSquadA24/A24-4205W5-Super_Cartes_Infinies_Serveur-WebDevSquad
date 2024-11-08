using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private PackService _packService;
        private PlayersService _playersService;

        public PackController(ApplicationDbContext dbContext, PackService packService, PlayersService playersService)
        {
            _dbContext = dbContext;
            _packService = packService;
            _playersService = playersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pack>> GetAllPacks()
        {
            return Ok(_packService.GetAllPacks());
        }

        [HttpGet("{packId}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetOpenPack(int packId)
        {
            var pack = await _dbContext.Packs.FindAsync(packId);
            var user = _dbContext.Users.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            var player = _playersService.GetPlayerFromUserId(user.Id);

            if (pack == null)
            {
                return NotFound("Pack non trouvé");
            }
            
            var cards = await _packService.OpenPack(pack, player);
            await _dbContext.SaveChangesAsync();
            return Ok(cards);
        }
    }
}
