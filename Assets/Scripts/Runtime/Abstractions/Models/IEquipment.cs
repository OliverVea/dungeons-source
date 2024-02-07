#nullable enable

using System.Collections.Generic;

namespace Runtime.Abstractions.Models
{
    public interface IEquipment
    {
        public string Name { get; }
        public IEquipmentModel? EquipmentModel { get; }
        
        IEnumerable<EquipmentSlot> EligibleSlots { get; }
        IEnumerable<EquipmentSlot> FillsSlotsWhenEquippedIn(EquipmentSlot equippedSlot);

        void Equip(Character character, EquipmentSlot equipmentSlot);
        void Unequip(Character character, EquipmentSlot equipmentSlot);
    }
}