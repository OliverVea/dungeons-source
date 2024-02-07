#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IEquipmentModelController
    {
        void Equip(Character character, IEquipmentModel equipmentModel, EquipmentSlot equipmentSlot);
        void Remove(Character character, IEquipmentModel equipmentModel);
    }
}