using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

//[Authorize]
public class MatchHub : Hub
{
    ApplicationDbContext _context;
    MatchesService _service;
    public MatchHub(ApplicationDbContext context, MatchesService service)
    {
        _context = context;
        _service = service;
    }

    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public override async Task OnConnectedAsync()
    {
        base.OnConnectedAsync();
        // TODO: Ajouter votre logique
        await Clients.Caller.SendAsync("UserId", Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        base.OnDisconnectedAsync(exception);
    }

    
    public async Task Connection(string userId)
    {
        base.OnConnectedAsync();
        UserHandler.ConnectedIds.Add(Context.ConnectionId);
        var connectedIdPlayerA = Context.ConnectionId;
        //await Clients.All.SendAsync("UserCount", UserHandler.ConnectedIds.Count);

        JoiningMatchData joiningMatchData = await _service.JoinMatch(userId, Context.ConnectionId, null);
        if(joiningMatchData != null)
        {
            var connectedIdPlayerB = joiningMatchData.OtherPlayerConnectionId;
            UserHandler.ConnectedIds.Add(connectedIdPlayerB);
            if (joiningMatchData.IsStarted)
            {
                await Clients.Caller.SendAsync("JoiningMatchData", joiningMatchData);
                await Clients.Caller.SendAsync("Id", userId);
                this.StartMatch(userId, joiningMatchData);


            }
            else
            {
                // Il faut tout de même envoyer le joiningMatchData au 2 joueurs


            }
        }

        // Appel JoinMatch
        // Décider quoi faire selon le JoinMatchData reçu
        // Si c'est null, on ne fait RIEN
        // Si ce n'est pas null, on envoit le matchData aux joueurs
        // Note: Si le match est déjà démarré, il faut seulement envoyer le match à celui qui a fait la requête
        // Si le match n'est pas déjà démarré, il faut faire un StartMatch et envoyer l'event aux clients
    }
    public async Task StartMatch(string userId, JoiningMatchData joiningMatchData)
    {
        StartMatchEvent startMatchEvent = await _service.StartMatch(userId, joiningMatchData.Match);
        //Envoyer à Player A
        await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("StartMatchEvent", startMatchEvent);

        //Envoyer à Player B
        await Clients.Caller.SendAsync("StartMatchEvent", startMatchEvent);
    }
    public async Task EndTurn(string userId)
    {
        PlayerEndTurnEvent endTurn = await _service.EndTurn(userId, 1);
        await Clients.Caller.SendAsync("EndTurn", endTurn);

    }
    public async Task Surrender(string userId)
    {
        await _service.Surrender(userId, 1);
    }
}