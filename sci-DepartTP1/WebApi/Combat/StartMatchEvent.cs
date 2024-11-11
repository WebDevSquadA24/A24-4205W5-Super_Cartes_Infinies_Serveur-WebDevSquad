﻿using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class StartMatchEvent : MatchEvent
    {
        public override string EventType { get { return "StartMatch"; } }
        public StartMatchEvent() { }
        public StartMatchEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbCardsToDraw, int nbManaPerTurn)
        {
            Events = new List<MatchEvent>();

            currentPlayerData.CardsPile = currentPlayerData.CardsPile.OrderBy(x => Random.Shared.Next()).ToList();
            opposingPlayerData.CardsPile = opposingPlayerData.CardsPile.OrderBy(x => Random.Shared.Next()).ToList();



            // TODO: Faire piger le nombre de cartes de la configuration (nbCardsToDraw) au DEUX joueurs
            for (int i = 0; i < nbCardsToDraw; i++)
            {
                Events.Add(new DrawCardEvent(currentPlayerData));
                Events.Add(new DrawCardEvent(opposingPlayerData));
            }

            Events.Add(new PlayerStartTurnEvent(currentPlayerData, nbManaPerTurn));
        }
    }
}
