#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;

namespace Runtime.Game.Controllers
{
    public class StatsController : IStatsController
    {
        public float GetHealth(Character character) => character.BaseStats.Health;
        public float GetHealthPerSecond(Character character) => 0;
        public float GetMana(Character character) => character.BaseStats.Mana;
        public float GetManaPerSecond(Character character) => character.BaseStats.ManaPerSecond;
        public float GetSpellPower(Character character) => character.BaseStats.SpellPower;
    }
}