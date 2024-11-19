using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class EndMatchEvent : MatchEvent
    {
        public EndMatchEvent()
        {
        }

        public override string EventType { get { return "EndMatch"; } }
        public int WinningPlayerId { get; set; }
        public int LosingPlayerId { get; set; }

        public double WinningMoney { get; set; }

        public double LosingMoney { get; set; }

        public double WinningReward { get; set; }

        public double LosingReward { get; set; }


        public EndMatchEvent(Match match, MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData)
        {
            // Pour l'instant, on n'arrête pas la simulation sur le serveur lorsqu'on atteint la fin de la partie.
            // Pour éviter qu'un joueur qui a gagné, mais qui meurt dans le même tour ne donne la victoire à l'autre, on vérifie si le match est déjà terminé!
            if (match.IsMatchCompleted)
                return;

            WinningPlayerId = winningPlayerData.PlayerId;
            LosingPlayerId = losingPlayerData.PlayerId;

            WinningReward = match.GameConfig.WinnerMoney;
            LosingReward = match.GameConfig.LoserMoney;

            winningPlayerData.Player.Money += WinningReward;
            losingPlayerData.Player.Money += LosingReward;

            //Nombre de victoires et de défaites sur Player 
            winningPlayerData.Player.NbVictories++;
            losingPlayerData.Player.NbDefeats++;

            //Nombre de victoires et de défaites sur Deck
            winningPlayerData.Player.Decks.Where(d => d.IsCurrent).FirstOrDefault().NbVictories++;
            losingPlayerData.Player.Decks.Where(d => d.IsCurrent).FirstOrDefault().NbDefeats++;

            WinningMoney = winningPlayerData.Player.Money;
            LosingMoney = losingPlayerData.Player.Money;

            match.IsMatchCompleted = true;

            string userId;
            if (match.PlayerDataA.PlayerId == winningPlayerData.PlayerId)
                userId = match.UserAId;
            else
                userId = match.UserBId;

            match.WinnerUserId = userId;
        }

    }
}
