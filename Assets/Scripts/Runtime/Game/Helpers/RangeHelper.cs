#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Helpers;
using UnityEngine;

namespace Runtime.Game.Helpers
{
    public class RangeHelper : IRangeHelper
    {
        public bool IsInRange(Character character, Character target, float maxRange)
        {
            var range = GetRange(character, target);
            
            return range <= maxRange;
        }

        public bool IsInRange(Character character, Vector3 position, float maxRange)
        {
            var range = GetRange(character, position);

            return range <= maxRange;
        }

        public float GetRange(Character character, Character target) => GetRange(character, target.Head);

        private float GetRange(Character character, Vector3 position)
        {
            var characterPosition = character.Head;

            var delta = characterPosition - position;

            return delta.magnitude;
        }
    }
}