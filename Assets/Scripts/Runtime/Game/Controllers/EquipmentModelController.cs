#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Controllers
{
    public class EquipmentModelController : IEquipmentModelController
    {
        public void Equip(Character character, IEquipmentModel equipmentModel, EquipmentSlot equipmentSlot)
        {
            character.EquipmentModelService.Equip(equipmentModel, equipmentSlot);
        }

        public void Remove(Character character, IEquipmentModel equipmentModel)
        {
            character.EquipmentModelService.Remove(equipmentModel);
        }
    }
}