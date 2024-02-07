#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Helpers
{
    public interface IRangeHelper
    {
        bool IsInRange(Character character, Character target, float maxRange);
        bool IsInRange(Character character, Vector3 position, float maxRange);
        float GetRange(Character character, Character target);
    }
}