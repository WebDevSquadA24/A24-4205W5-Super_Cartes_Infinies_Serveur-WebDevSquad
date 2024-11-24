
using Humanizer;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
using Match = Super_Cartes_Infinies.Models.Match;

namespace WebApi.Services
{
    public class EloBackGroundService : BackgroundService
    {
        public const int CONSTANTE = 1 * 1000;

        private IHubContext<MatchHub> _matchHub;

        private IServiceScopeFactory _serviceScopeFactory;

        private PlayersService _playersService;
        private CardsService _cardsService;
        private MatchesService _service;



        public EloBackGroundService(IHubContext<MatchHub> monHub, IServiceScopeFactory serviceScopeFactory, PlayersService playersService, CardsService cardsService, MatchesService service)
        {
            _matchHub = monHub;
            _serviceScopeFactory = serviceScopeFactory;
            _playersService = playersService;
            _cardsService = cardsService;
            _service = service;


        }


        // NEED A FUNCTION TO ADD PLAYERINFO TO DATABASE
        public void AddPlayerInfo(string userId, int Elo, int attente)
        {

        }


        public Match CreateMatch(PairOfPlayers pairOfPlayers)
        {
            Player? playerA = _playersService.GetPlayerFromUserId(pairOfPlayers.UserAId);
            Player? playerB = _playersService.GetPlayerFromUserId(pairOfPlayers.UserBId);

            //// Création d'un nouveau match
            IEnumerable<Card> cards = _cardsService.GetAllCards();
            Match match = new Match(playerA, playerB, cards);
            return match;
        }

        public JoiningMatchData CreateJoiningMatch(Match match, PairOfPlayers pairOfPlayers)
        {
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
            Player? playerA = _playersService.GetPlayerFromUserId(pairOfPlayers.UserAId);
            Player? playerB = _playersService.GetPlayerFromUserId(pairOfPlayers.UserBId);
            JoiningMatchData joiningMatchData = new JoiningMatchData{
                Match = match,
                PlayerA = playerA!,
                PlayerB = playerB!,
                OtherPlayerConnectionId = pairOfPlayers.OtherConnectionId,
                IsStarted = true,

            };
            return joiningMatchData;
        }

        // Passer une COPIE de l'information sur les players (Car on va retirer les éléments de la liste, même si le player n'est pas mis dans une paire)
        async Task GeneratePairsAsync(List<PlayerInfo> playerInfos)
        {
            List<PairOfPlayers> pairs = new List<PairOfPlayers>();
            int index = -1;
            int smallestELODifference = int.MaxValue;
            PlayerInfo playerInfo2 = null;
            PlayerInfo playerInfo = null;
            string groupName = "";
             
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
                PairOfPlayers pairOfPlayers = new PairOfPlayers(playerInfo, playerInfo2);
                pairs.Add(pairOfPlayers);


                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Update db With PlayerInfo (REMOVE)
                    dbContext.PlayerInfo.Remove(playerInfo);
                    dbContext.PlayerInfo.Remove(playerInfo2);

                    // Créer le match
                    Match match = CreateMatch(pairOfPlayers);

                    string otherPlayerConnectionId = null;

                    dbContext.Update(match);
                    dbContext.SaveChangesAsync();

                    //Créer le JoiningMatchData
                    JoiningMatchData joiningMatchData = CreateJoiningMatch(match, pairOfPlayers);

                    groupName = "Match" + joiningMatchData.Match.Id;

                    await _matchHub.Groups.AddToGroupAsync(playerInfo.ConnectionId, groupName);
                    await _matchHub.Groups.AddToGroupAsync(playerInfo2.ConnectionId, groupName);

                    await _matchHub.Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);

                    StartMatchEvent startMatchEvent = await _service.StartMatch(playerInfo2.UserId, joiningMatchData.Match);

                    await _matchHub.Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);



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
                    GeneratePairsAsync(dbContext.PlayerInfo.ToList());

                }
            }
        }


    }
}
