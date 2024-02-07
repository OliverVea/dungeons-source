#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IEquipmentModelService
    {
        void Equip(IEquipmentModel equipmentModel, EquipmentSlot equipmentSlot);
        void Remove(IEquipmentModel equipmentModel);
    }
}