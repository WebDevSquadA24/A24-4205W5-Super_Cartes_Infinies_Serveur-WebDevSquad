
using Microsoft.AspNetCore.SignalR;
using Models.Models;
using Super_Cartes_Infinies.Hubs;

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
             }

            // Sinon, c'est pas grave, on a retiré l'élément de la liste et on va évaluer le prochain
            return pairs;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Until it ends
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(CONSTANTE, stoppingToken);

            }
        }


    }
}
