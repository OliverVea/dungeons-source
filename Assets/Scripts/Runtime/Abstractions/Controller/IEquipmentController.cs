#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IEquipmentController
    {
        void Equip(Character character, IEquipment equipment, EquipmentSlot equipmentSlot);
        void Remove(Character character, EquipmentSlot equippedSlot);
        IEquipment? GetEquipmentForSlot(Character character, EquipmentSlot equipmentSlot);
    }
}