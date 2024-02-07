#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Controllers
{
    public class InventoryController : IInventoryController
    {
        public void AddItem(Character character, IInventoryItem item)
        {
            character.InventoryService.AddItem(item);
        }

        public void RemoveItem(Character character, IInventoryItem item)
        {
            character.InventoryService.RemoveItem(item);
        }
    }
}