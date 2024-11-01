using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System.Text.RegularExpressions;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
        public int PlayableCardId { get; set; }

        // TODO: Ajouter tout ce qui manque
        public PlayCardEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int playableCardId)
        {
            int maxCarte = 6;
            if (currentPlayerData.Hand.Count > 0)
            {
                PlayableCard playableCard = currentPlayerData.Hand.Where(h => h.Id == playableCardId).First();

                if (playableCard.Card.Cost < currentPlayerData.Mana)
                {
                    if (currentPlayerData.BattleField.Count < maxCarte)
                    {
                        PlayableCardId = playableCardId;

                        currentPlayerData.Mana -= playableCard.Card.Cost;

                        currentPlayerData.Hand.Remove(playableCard);
                        currentPlayerData.BattleField.Add(playableCard);
                    }
                }
            }
        }
    }
}
