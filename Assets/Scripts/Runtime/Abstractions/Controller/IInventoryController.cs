#nullable enable
using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IInventoryController
    {
        void AddItem(Character character, IInventoryItem item);
        void RemoveItem(Character character, IInventoryItem item);
    }
}