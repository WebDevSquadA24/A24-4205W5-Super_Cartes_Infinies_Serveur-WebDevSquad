﻿using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System.Text.RegularExpressions;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
        public int PlayableCardId { get; set; }

        public int PlayerId { get; set; }

        public bool CanMoveCard { get; set; }

        public int Cost{get;set;}

        public bool YourTurn { get; set; }

        // TODO: Ajouter tout ce qui manque
        public PlayCardEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int playableCardId, bool yourTurn)
        {
            CanMoveCard = false;
            YourTurn = yourTurn;
            int maxCarte = 5;

            // C'est tu ton tour?
            if (yourTurn)
            {
                PlayerId = currentPlayerData.PlayerId;

                // T'as tu plus que 0 carte dans ta main
                if (currentPlayerData.Hand.Count > 0)
                {
                    PlayableCard playableCard = currentPlayerData.Hand.Where(h => h.Id == playableCardId).First();
                    PlayableCardId = playableCard.Id;
                    Cost = playableCard.Card.Cost;


                    //Est-ce que t'as assez de Mana
                    if (playableCard.Card.Cost <= currentPlayerData.Mana)
                    {
                        if (playableCard.Card.IsSpell)
                        {
                            PlayableCardId = playableCardId;
                            currentPlayerData.Mana -= playableCard.Card.Cost;
                            currentPlayerData.Hand.Remove(playableCard);

                            if (playableCard.HasPower(Power.EARTHQUAKE_ID))
                            {
                                if (Events == null) Events = new List<MatchEvent>();
                                Events.Add(new EarthquakeEvent(currentPlayerData, opposingPlayerData, playableCard.GetPowerValue(Power.EARTHQUAKE_ID)));
                            }
                            if (playableCard.HasPower(Power.RANDOM_PAIN_ID))
                            {

                            }

                            currentPlayerData.Graveyard.Add(playableCard);
                        }
                        // Est-ce qu'il y a de l'espace sur le terrain
                        else if (currentPlayerData.BattleField.Count < maxCarte)
                        {
                            PlayableCardId = playableCardId;

                            currentPlayerData.Mana -= playableCard.Card.Cost;

                            currentPlayerData.AddCardToBattleField(playableCard);

                            CanMoveCard = true;
                        }
                    }
                }
            }
           
        }
    }
}
