#nullable enable

using System.Collections.Generic;

namespace Runtime.Abstractions.Managers
{
    public interface IPartyManager
    {
        IEnumerable<Character> GetOrderedParty();
    }
}