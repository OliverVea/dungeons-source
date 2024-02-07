#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;

namespace Runtime.Game.Extensions
{
    public static class CharacterListExtensions
    {
        public static IEnumerable<Character> ThatAreTargeting(
            this IEnumerable<Character> characters,
            Character target,
            ITargetController targetController)
        {
            return characters.Where(x => targetController.IsTargeting(x, target));
        }

        public static void SetTarget(
            this IEnumerable<Character> characters,
            Character? target,
            ITargetController targetController)
        {
            foreach (var character in characters) targetController.SetTarget(character, target);
        }

        public static void AddThreatTo(
            this IEnumerable<Character> characters,
            Character target,
            float threat,
            IThreatController threatController)
        {
            foreach (var character in characters) threatController.AddThreat(target, character, threat);
        }

        public static void AddThreatFrom(
            this IEnumerable<Character> characters,
            Character target,
            float threat,
            IThreatController threatController)
        {
            foreach (var character in characters) threatController.AddThreat(character, target, threat);
        }

        public static void DropThreatTo(
            this IEnumerable<Character> characters,
            Character target,
            IThreatController threatController)
        {
            foreach (var character in characters) threatController.DropThreat(character, target);
        }

        public static IEnumerable<Character> ThatAreInRangeOf(
            this IEnumerable<Character> characters,
            Character character,
            float maxRange,
            IRangeHelper rangeHelper)
        {
            return characters.Where(x => rangeHelper.IsInRange(x, character, maxRange));
        }

        public static IEnumerable<Character> OfEnemyFaction(
            this IEnumerable<Character> characters,
            Character character,
            IFactionHelper factionHelper)
        {
            return characters.Where(x => factionHelper.AreEnemies(x, character));
        }

        public static IEnumerable<Character> OfSameFaction(
            this IEnumerable<Character> characters,
            Character character,
            IFactionHelper factionHelper)
        {
            return characters.Where(x => factionHelper.SameFaction(x, character));
        }
    }
}