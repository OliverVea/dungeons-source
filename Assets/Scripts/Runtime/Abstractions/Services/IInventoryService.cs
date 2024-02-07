#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IInventoryService
    {
        void AddItem(IInventoryItem item);
        void RemoveItem(IInventoryItem item);
        IEnumerable<IInventoryItem> ListItems();
    }
}