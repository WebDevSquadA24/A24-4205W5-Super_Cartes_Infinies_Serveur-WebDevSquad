using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class EndMatchEvent : MatchEvent
    {

        private ApplicationDbContext _dbContext;

        public EndMatchEvent(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public override string EventType { get { return "EndMatch"; } }
        public int WinningPlayerId { get; set; }
        public int LosingPlayerId { get; set; }


        public EndMatchEvent(Match match, MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData)
        {
            // Pour l'instant, on n'arrête pas la simulation sur le serveur lorsqu'on atteint la fin de la partie.
            // Pour éviter qu'un joueur qui a gagné, mais qui meurt dans le même tour ne donne la victoire à l'autre, on vérifie si le match est déjà terminé!
            if (match.IsMatchCompleted)
                return;

            WinningPlayerId = winningPlayerData.PlayerId;
            LosingPlayerId = losingPlayerData.PlayerId;

            match.IsMatchCompleted = true;

            string userId;
            if (match.PlayerDataA.PlayerId == winningPlayerData.PlayerId)
                userId = match.UserAId;
            else
                userId = match.UserBId;

            match.WinnerUserId = userId;
        }

        public void AwardRewards()
        {
            var gameConfig = _dbContext.GameConfigs.FirstOrDefault();

            double winningReward = gameConfig.WinnerMoney;
            double losingReward = gameConfig.LoserMoney;

            var winningPlayer = _dbContext.Players.Find(WinningPlayerId);
            var losingPlayer = _dbContext.Players.Find(LosingPlayerId);

            if (winningPlayer != null)
            {
                winningPlayer.Money += winningReward;
            }

            if (losingPlayer != null)
            {
                losingPlayer.Money += losingReward;
            }

            _dbContext.SaveChanges();
        }
    }
}
