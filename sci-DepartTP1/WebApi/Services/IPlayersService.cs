using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Models;

namespace WebApi.Services
{
    public interface IPlayersService
    {
        public Player GetPlayerFromUserId(string userId);
    }
}
