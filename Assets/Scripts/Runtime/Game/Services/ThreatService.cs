# nullable enable

using System.Collections.Generic;
using Runtime.Abstractions;

namespace Runtime.Game.Services
{
    public class ThreatService : IThreatService
    {
         private readonly Dictionary<Character, float> _threatTable = new();

         public void AddThreat(Character characterId, float threat)
         {
             if (!_threatTable.ContainsKey(characterId))
             {
                 _threatTable[characterId] = threat;
                 return;
             }
                 
             _threatTable[characterId] += threat;
         }

         public IReadOnlyDictionary<Character, float> GetThreatTable()
         {
             return _threatTable;
         }

         public void DropThreat(Character target)
         {
             _threatTable.Remove(target);
         }

         public float GetThreat(Character characterId)
         {
             return _threatTable.TryGetValue(characterId, out var value) ? value : 0;
         }
    }
}