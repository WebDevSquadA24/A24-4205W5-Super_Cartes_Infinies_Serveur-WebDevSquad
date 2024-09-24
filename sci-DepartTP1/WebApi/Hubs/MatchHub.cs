using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

//[Authorize]
public class MatchHub : Hub
{
    ApplicationDbContext _context;
    MatchesService _service;
    PlayersService _playerService;
    public MatchHub(ApplicationDbContext context, MatchesService service, PlayersService playersService)
    {
        _context = context;
        _service = service;
        _playerService = playersService;
    }
    public IdentityUser CurentUser
    {
        get
        {
            string userid = Context.UserIdentifier!;

            var user = _context.Users.Single(u => u.Id == userid);

            return user;
        }

    }
    public static class UserHandler
    {
        public static Dictionary<string, string> UserConnections { get; set; } = new Dictionary<string, string>();
    }


    public override async Task OnConnectedAsync()
    {

        await base.OnConnectedAsync();


    }

    public async Task Connecter()
    {
        
    }

    public async Task Connection(string userId)
    {
        //UserHandler.ConnectedIds.Add(Context.ConnectionId);
        var connectedIdPlayerA = Context.ConnectionId;
        //await Clients.All.SendAsync("UserCount", UserHandler.ConnectedIds.Count);

        JoiningMatchData? joiningMatchData = await _service.JoinMatch(userId, Context.ConnectionId, null);
        if(joiningMatchData != null)
        {
            string groupName = "Match" + joiningMatchData.Match.Id;
            //UserHandler.ConnectedIds.Add(connectedIdPlayerB);
            if (joiningMatchData.IsStarted)
            {

                //Celui qui appelle la métohde
                await Clients.Caller.SendAsync("JoiningMatchData", joiningMatchData);
                


            }
            else
            {
                //UserB
                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                //UserA
                await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);

                // Il faut tout de même envoyer le joiningMatchData au 2 joueurs
                await this.StartMatch(userId, joiningMatchData, groupName);
               

            }
        }

        // Appel JoinMatch
        // Décider quoi faire selon le JoinMatchData reçu
        // Si c'est null, on ne fait RIEN
        // Si ce n'est pas null, on envoit le matchData aux joueurs
        // Note: Si le match est déjà démarré, il faut seulement envoyer le match à celui qui a fait la requête
        // Si le match n'est pas déjà démarré, il faut faire un StartMatch et envoyer l'event aux clients
    }
    public async Task StartMatch(string userId, JoiningMatchData joiningMatchData, string groupName)
    {
       

        StartMatchEvent startMatchEvent = await _service.StartMatch(userId, joiningMatchData.Match);
        //Envoyer à Player A et B
        await Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);


        await Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);


    }

    public async Task EndTurn(string userId, JoiningMatchData joiningMatchData)
    {
        PlayerEndTurnEvent endTurn = await _service.EndTurn(userId, joiningMatchData.Match.Id);

        //current player
        Player player = _playerService.GetPlayerFromUserId(userId);

        string groupName = "Match" + joiningMatchData.Match.Id;

        await Clients.Group(groupName).SendAsync("EndTurn", endTurn);

    }
    public async Task Surrender(string userId, JoiningMatchData joiningMatchData)
    {
        SurrenderEvent surrenderEvent = await _service.Surrender(userId, joiningMatchData.Match.Id);

        Player player = _playerService.GetPlayerFromUserId(userId);
        string groupName = "Match" + joiningMatchData.Match.Id;

        await Clients.Group(groupName).SendAsync("Surrender", surrenderEvent);
    }
}