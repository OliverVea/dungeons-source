#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HashSet<IInventoryItem> _items = new();
        
        public void AddItem(IInventoryItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IInventoryItem item)
        {
            _items.Remove(item);
        }

        public IEnumerable<IInventoryItem> ListItems()
        {
            return _items.ToArray();
        }
    }
}