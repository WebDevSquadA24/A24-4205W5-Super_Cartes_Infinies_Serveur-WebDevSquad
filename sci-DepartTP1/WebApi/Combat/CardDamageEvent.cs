﻿using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType { get { return "CardDamage"; } }
    }
}
