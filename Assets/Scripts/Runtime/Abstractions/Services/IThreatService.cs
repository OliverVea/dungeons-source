# nullable enable

using System.Collections.Generic;

namespace Runtime.Abstractions
{
    public interface IThreatService
    {
        void AddThreat(Character characterId, float threat);
        IReadOnlyDictionary<Character, float> GetThreatTable ();
        void DropThreat(Character target);
        float GetThreat(Character characterId);
    }
}