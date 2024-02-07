#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Helpers
{
    public class FactionHelper : IFactionHelper
    {
        public bool AreEnemies(Character character, Character target)
        {
            if (character.Faction == Faction.None) return false;
            if (target.Faction == Faction.None) return false;

            return character.Faction != target.Faction;
        }

        public bool SameFaction(Character character, Character target)
        {
            if (character.Faction == Faction.None) return false;
            if (target.Faction == Faction.None) return false;

            return character.Faction == target.Faction;
        }
    }
}