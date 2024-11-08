using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.Text.RegularExpressions;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Hubs;

[Authorize]
public class MatchHub : Hub
{
    ApplicationDbContext _context;
    MatchesService _service;
    PlayersService _playerService;
    WaitingUserService _waitingUserService;
    public MatchHub(ApplicationDbContext context, MatchesService service, PlayersService playersService, WaitingUserService waitingUserService)
    {
        _context = context;
        _service = service;
        _playerService = playersService;
        _waitingUserService = waitingUserService;
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

    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        base.OnDisconnectedAsync(exception);
        // TODO: Ajouter votre logique
        await _service.StopJoiningMatch(CurentUser.Id);
        
    }


    public async Task Connection()
    {
        

        string userId = CurentUser.Id;
        //UserHandler.ConnectedIds.Add(Context.ConnectionId);
        var connectedIdPlayerA = Context.ConnectionId;
        //await Clients.All.SendAsync("UserCount", UserHandler.ConnectedIds.Count);

        JoiningMatchData? joiningMatchData = await _service.JoinMatch(userId, Context.ConnectionId, null);
        if(joiningMatchData != null)
        {
            string groupName = "Match" + joiningMatchData.Match.Id;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //UserHandler.ConnectedIds.Add(connectedIdPlayerB);
            if (joiningMatchData.IsStarted)
            {

                //Celui qui appelle la métohde
                await Clients.Caller.SendAsync("JoiningMatchData", joiningMatchData);
                


            }
            else
            {
                //UserA
                await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);

                // Il faut tout de même envoyer le joiningMatchData au 2 joueurs
                await this.StartMatch(userId, joiningMatchData, groupName);
               

            }
        }
        else
        {
            await Clients.Caller.SendAsync("JoiningMatchData", null);
        }

    }
    public async Task StartMatch(string userId, JoiningMatchData joiningMatchData, string groupName)
    {
       

        //Envoyer à Player A et B
        await Clients.Group(groupName).SendAsync("JoiningMatchData", joiningMatchData);
        StartMatchEvent startMatchEvent = await _service.StartMatch(userId, joiningMatchData.Match);


        await Clients.Group(groupName).SendAsync("StartMatchEvent", startMatchEvent);


    }

    public async Task EndTurn(JoiningMatchData joiningMatchData)
    {
        string userId = CurentUser.Id;

        PlayerEndTurnEvent endTurn = await _service.EndTurn(userId, joiningMatchData.Match.Id);

        //current player
        Player player = _playerService.GetPlayerFromUserId(userId);

        string groupName = "Match" + joiningMatchData.Match.Id;

        await Clients.Group(groupName).SendAsync("EndTurn", endTurn);

    }
    public async Task Surrender( JoiningMatchData joiningMatchData)
    {

        string userId = CurentUser.Id;

        SurrenderEvent surrenderEvent = await _service.Surrender(userId, joiningMatchData.Match.Id);

        Player player = _playerService.GetPlayerFromUserId(userId);
        string groupName = "Match" + joiningMatchData.Match.Id;

        await Clients.Group(groupName).SendAsync("Surrender", surrenderEvent);
    }

    public async Task PlayCard(JoiningMatchData joiningMatchData, int playableId)
    {

        string userId = CurentUser.Id;

        MatchPlayerData currentPlayerData;
        MatchPlayerData opposingPlayerData;
        Player player = _playerService.GetPlayerFromUserId(userId);

        bool yourTurn = false;



        if (userId == joiningMatchData.Match.UserAId)
        {
            currentPlayerData = joiningMatchData.Match.PlayerDataA;
            opposingPlayerData = joiningMatchData.Match.PlayerDataB;
            yourTurn = joiningMatchData.Match.IsPlayerATurn;
        }
        else
        {
            currentPlayerData = joiningMatchData.Match.PlayerDataB;
            opposingPlayerData = joiningMatchData.Match.PlayerDataA;
            yourTurn = !joiningMatchData.Match.IsPlayerATurn;
        }

        PlayCardEvent playEvent = new PlayCardEvent(currentPlayerData, opposingPlayerData, playableId, yourTurn);

        string groupName = "Match" + joiningMatchData.Match.Id;

        await Clients.Group(groupName).SendAsync("PlayCard", playEvent);
    }



}