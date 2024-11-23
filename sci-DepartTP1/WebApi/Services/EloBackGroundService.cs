
using Humanizer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Hubs;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.Text.RegularExpressions;

namespace WebApi.Services
{
    public class EloBackGroundService : BackgroundService
    {
        public const int CONSTANTE = 1 * 1000;

        private IHubContext<MatchHub> _matchHub;

        private IServiceScopeFactory _serviceScopeFactory;

        private List<PairOfPlayers> pairs;

        private PlayerInfo playerInfo;

        public EloBackGroundService(IHubContext<MatchHub> monHub, IServiceScopeFactory serviceScopeFactory)
        {
            _matchHub = monHub;
            _serviceScopeFactory = serviceScopeFactory;
        }


        // NEED A FUNCTION TO ADD PLAYERINFO TO DATABASE
        public void AddPlayerInfo(string userId, int Elo, int attente)
        {

        }

        // Passer une COPIE de l'information sur les players (Car on va retirer les éléments de la liste, même si le player n'est pas mis dans une paire)
        List<PairOfPlayers> GeneratePairs(List<PlayerInfo> playerInfos)
        {
            pairs = new List<PairOfPlayers>();
            int index = -1;
            int smallestELODifference = int.MaxValue;
            PlayerInfo playerInfo2 = null;


            // Tant qu'il y a des joueurs à mettre en pair
            while (playerInfos.Count > 0)
            {
                playerInfo = playerInfos[0];
                playerInfos.Remove(playerInfo);
                for (int i = 0; i < playerInfos.Count; i++)
                {
                    PlayerInfo pi = playerInfos[i];
                    int difference = Math.Abs(pi.ELO - playerInfo.ELO);
                    if (difference < playerInfo.attente * CONSTANTE)
                    {
                        if (difference < smallestELODifference)
                            smallestELODifference = difference;
                        index = i;
                    }
                
                }
                    
            }

            // Si on a trouvé une paire
            if (index >= 0)
            {
                playerInfo2 = playerInfos[index];
                playerInfos.RemoveAt(index);
                pairs.Add(new PairOfPlayers(playerInfo, playerInfo2));

                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    // Update db With PairofPlayers (REMOVE)

                    // JoiningMatchdata
                    //-------------------------------------------------------------------------
                    //if (match != null)
                    //{
                    //    return new JoiningMatchData
                    //    {
                    //        Match = match,
                    //        PlayerA = playerA!,
                    //        PlayerB = playerB!,
                    //        OtherPlayerConnectionId = otherPlayerConnectionId,
                    //        IsStarted = otherPlayerConnectionId == null
                    //    };
                    //}
                    //-------------------------------------------------------------------------



                    // Create match
                    //----------------------------------------------------------------------------

                    //playerA = _playersService.GetPlayerFromUserId(pairOfUsers.UserAId);
                    //playerB = _playersService.GetPlayerFromUserId(pairOfUsers.UserBId);

                    //// Création d'un nouveau match
                    //IEnumerable<Card> cards = _cardsService.GetAllCards();
                    //match = new Match(playerA, playerB, cards);
                    //otherPlayerConnectionId = pairOfUsers.UserAConnectionId;

                    //_dbContext.Update(match);
                    //_dbContext.SaveChanges();

                    // We would like to send to the client the necessary information
                    //----------------------------------------------------------------------------

                    // await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);

                    //Envoyer à Player A et B
                    //await Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);
                    //StartMatchEvent startMatchEvent = await _service.StartMatch(userId, joiningMatchData.Match);


                    //await Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);

                    //----------------------------------------------------------------------------
                }

            }

            // Sinon, c'est pas grave, on a retiré l'élément de la liste et on va évaluer le prochain
            return pairs;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Until it ends
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(CONSTANTE, stoppingToken);
                    //INCRÉMENTER Propriété attente dans PLAYERIFNO
                    // --
                    //Update database
                    GeneratePairs(dbContext.PlayerInfo.ToList());

                }
            }
        }


    }
}
