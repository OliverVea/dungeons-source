#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly Dictionary<EquipmentSlot, IEquipment> _equippedItems = new();
        
        public void Equip(IEquipment equipment, IEnumerable<EquipmentSlot> equipmentSlots)
        {
            foreach (var slot in equipmentSlots) _equippedItems[slot] = equipment;
        }

        public void Remove(EquipmentSlot equippedSlot)
        {
            var equipment = GetEquipmentForSlot(equippedSlot);
            if (equipment is null) return;

            foreach (var slot in _equippedItems.Keys.ToArray())
            {
                if (_equippedItems[slot] == equipment) _equippedItems.Remove(slot);
            }
        }

        public IEquipment? GetEquipmentForSlot(EquipmentSlot equipmentSlot)
        {
            return _equippedItems.TryGetValue(equipmentSlot, out var equipment) ? equipment : null;
        }
    }
}