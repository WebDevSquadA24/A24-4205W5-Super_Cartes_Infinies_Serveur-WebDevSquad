﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private PackService _packService;

        public PackController(ApplicationDbContext dbContext, PackService packService)
        {
            _dbContext = dbContext;
            _packService = packService;
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

            if (pack == null)
            {
                return NotFound("Pack non trouvé");
            }

            var cards = await _packService.OpenPack(pack);
            return Ok(cards);
        }
    }
}
