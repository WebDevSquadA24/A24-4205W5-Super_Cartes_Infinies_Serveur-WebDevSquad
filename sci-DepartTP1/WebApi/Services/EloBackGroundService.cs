
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
        public const int CONSTANTE = 1;

        private IHubContext<MatchHub> _matchHub;

        private IServiceScopeFactory _serviceScopeFactory;

        public List<PairOfPlayers> _PairOfPlayers;



        public EloBackGroundService(IHubContext<MatchHub> monHub, IServiceScopeFactory serviceScopeFactory)
        {
            _matchHub = monHub;
            _serviceScopeFactory = serviceScopeFactory;
        }


        // NEED A FUNCTION TO ADD PLAYERINFO TO DATABASE
        private async Task AssemblageData(PairOfPlayers pairOfPlayers, ApplicationDbContext dbContext)
        {
            Match match = CreateMatch(pairOfPlayers, dbContext);

            string otherPlayerConnectionId = null;

            dbContext.Update(match);
            await dbContext.SaveChangesAsync();

            //Créer le JoiningMatchData
            JoiningMatchData joiningMatchData = CreateJoiningMatch(match, pairOfPlayers, dbContext);

            string groupName = "Match" + joiningMatchData.Match.Id;

            await _matchHub.Groups.AddToGroupAsync(pairOfPlayers.PlayerInfo1.ConnectionId, groupName);
            await _matchHub.Groups.AddToGroupAsync(pairOfPlayers.PlayerInfo2.ConnectionId, groupName);

            await _matchHub.Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);

            StartMatchEvent startMatchEvent = await StartMatch(pairOfPlayers.PlayerInfo2.UserId, joiningMatchData.Match, dbContext);


            await _matchHub.Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);
        }


        public Match CreateMatch(PairOfPlayers pairOfPlayers, ApplicationDbContext dbContext)
        {
            
                Player? playerA = dbContext.Players.Single(p => p.UserId == pairOfPlayers.UserAId);
                Player? playerB = dbContext.Players.Single(p => p.UserId == pairOfPlayers.UserBId);

                //// Création d'un nouveau match
                IEnumerable<Card> cards = dbContext.Cards;
                Match match = new Match(playerA, playerB, cards);

                return match;



        }

        public async Task<StartMatchEvent> StartMatch(string currentUserId, Match match, ApplicationDbContext dbContext)
        {
           

                if ((match.UserAId == currentUserId) != match.IsPlayerATurn)
                    throw new Exception("Ce n'est pas le tour de ce joueur");

                MatchPlayerData currentPlayerData;
                MatchPlayerData opposingPlayerData;

                if (match.UserAId == currentUserId)
                {
                    currentPlayerData = match.PlayerDataA;
                    opposingPlayerData = match.PlayerDataB;
                }
                else
                {
                    currentPlayerData = match.PlayerDataB;
                    opposingPlayerData = match.PlayerDataA;
                }

                int nbCardsToDraw = dbContext.GameConfigs.First().NbCardsToDraw;
                int nbManaPerTurn = dbContext.GameConfigs.First().NbManaToReceive;
                var startMatchEvent = new StartMatchEvent(match, currentPlayerData, opposingPlayerData, nbCardsToDraw, nbManaPerTurn);

                await dbContext.SaveChangesAsync();

                return startMatchEvent;


        }

        public JoiningMatchData CreateJoiningMatch(Match match, PairOfPlayers pairOfPlayers, ApplicationDbContext dbContext)
        {

                Player? playerA = dbContext.Players.Single(p => p.UserId == pairOfPlayers.UserAId);
                Player? playerB = dbContext.Players.Single(p => p.UserId == pairOfPlayers.UserBId);
                JoiningMatchData joiningMatchData = new JoiningMatchData
                {
                    Match = match,
                    PlayerA = playerA!,
                    PlayerB = playerB!,
                    OtherPlayerConnectionId = pairOfPlayers.OtherConnectionId,
                    IsStarted = true,

                };
                return joiningMatchData;


               
        }

        // Passer une COPIE de l'information sur les players (Car on va retirer les éléments de la liste, même si le player n'est pas mis dans une paire)
        public static  async Task<List<PairOfPlayers>> GeneratePairsAsync(List<PlayerInfo> playerInfos, ApplicationDbContext dbContext)
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
                            {
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
                    // TODO: Vérifier ce qui est fait avec le OtherConnectionId vs le userId qui est attendu dans StartMatch
                    pairOfPlayers.OtherConnectionId = playerInfo2.ConnectionId;
                    pairs.Add(pairOfPlayers);


                    // Update db With PlayerInfo (REMOVE)
                    dbContext.PlayerInfo.Remove(playerInfo);
                    dbContext.PlayerInfo.Remove(playerInfo2);
                    await dbContext.SaveChangesAsync();

                }


                #region Comment
                // Créer le match -----------------------------------------------------------------
                //Match match = CreateMatch(pairOfPlayers);

                //        string otherPlayerConnectionId = null;

                //        dbContext.Update(match);
                //        await dbContext.SaveChangesAsync();

                //        //Créer le JoiningMatchData
                //        JoiningMatchData joiningMatchData = CreateJoiningMatch(match, pairOfPlayers, dbContext);

                //        groupName = "Match" + joiningMatchData.Match.Id;

                //        await _matchHub.Groups.AddToGroupAsync(playerInfo.ConnectionId, groupName);
                //        await _matchHub.Groups.AddToGroupAsync(playerInfo2.ConnectionId, groupName);

                //        await _matchHub.Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);

                //        StartMatchEvent startMatchEvent = await StartMatch(playerInfo2.UserId, joiningMatchData.Match , dbContext);


                //        await _matchHub.Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);



                // We would like to send to the client the necessary information
                //----------------------------------------------------------------------------

                // await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);

                //Envoyer à Player A et B
                //await Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);
                //StartMatchEvent startMatchEvent = await _service.StartMatch(userId, joiningMatchData.Match);


                //await Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);

                //----------------------------------------------------------------------------
                #endregion

            }
            return pairs;


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
                    await Task.Delay(CONSTANTE * 1000, stoppingToken);
                    //INCRÉMENTER Propriété attente dans PLAYERIFNO
                    // --
                    //Update database
                    foreach (PlayerInfo player in dbContext.PlayerInfo)
                    {
                        player.attente++;
                        dbContext.PlayerInfo.Update(player);
                        dbContext.SaveChanges();
                    }
                    List<PlayerInfo> playerInfos = dbContext.PlayerInfo.ToList();

                    List<PairOfPlayers> listePlayers = await GeneratePairsAsync(playerInfos, dbContext);
                    foreach(PairOfPlayers p in listePlayers)
                    {
                        await AssemblageData(p, dbContext);

                    }


                }
            }
        }


    }
}
