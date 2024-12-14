using System.Text.Json.Serialization;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    [JsonDerivedType(typeof(DrawCardEvent))]
    [JsonDerivedType(typeof(EndMatchEvent))]
    [JsonDerivedType(typeof(GainManaEvent))]
    [JsonDerivedType(typeof(PlayerEndTurnEvent))]
    [JsonDerivedType(typeof(PlayerStartTurnEvent))]
    [JsonDerivedType(typeof(StartMatchEvent))]
    [JsonDerivedType(typeof(SurrenderEvent))]
    [JsonDerivedType(typeof(CombatEvent))]
    [JsonDerivedType(typeof(CardActivationEvent))]
    [JsonDerivedType(typeof(HealEvent))]
    [JsonDerivedType(typeof(CardHealEvent))]
    [JsonDerivedType(typeof(ThornsEvent))]
    [JsonDerivedType(typeof(CardDamageEvent))]
    [JsonDerivedType(typeof(AttackEvent))]
    [JsonDerivedType(typeof(FirstStrikeEvent))]
    [JsonDerivedType(typeof(CardDeathEvent))]
    [JsonDerivedType(typeof(PlayerDamageEvent))]
    [JsonDerivedType(typeof(PlayerDeathEvent))]
    [JsonDerivedType(typeof(LoveOfJesusChristEvent))]
    [JsonDerivedType(typeof(ChaosEvent))]
    [JsonDerivedType(typeof(StunEvent))]
    [JsonDerivedType(typeof(StunnedEvent))]
    [JsonDerivedType(typeof(PoisonEvent))]
    [JsonDerivedType(typeof(PoisonedEvent))]
    [JsonDerivedType(typeof(EarthquakeEvent))]
    [JsonDerivedType(typeof(RandomPainEvent))]
    [JsonDerivedType(typeof(TalibanEvent))]
    public abstract class MatchEvent
    {
        public abstract string EventType { get; }

        public MatchEvent()
        {

        }

        public List<MatchEvent>? Events { get; set; }
    }
}
