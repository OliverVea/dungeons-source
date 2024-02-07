#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IEquipmentService
    {
        void Equip(IEquipment equipment, IEnumerable<EquipmentSlot> equipmentSlot);
        void Remove(EquipmentSlot equippedSlot);
        IEquipment? GetEquipmentForSlot(EquipmentSlot equipmentSlot);
    }
}