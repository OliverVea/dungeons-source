#nullable enable

using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Controllers
{
    public class EquipmentController : IEquipmentController
    {
        [Inject] private readonly ILogger _logger = null!;
        [Inject] private readonly IEquipmentModelController _equipmentModelController = null!;
        
        public void Equip(Character character, IEquipment equipment, EquipmentSlot equipmentSlot)
        {
            if (!IsEligibleSlot(equipment, equipmentSlot))
            {
                _logger.Log($"{character.Name} tried to equip {equipment.Name} in invalid slot {equipmentSlot}");
                return;
            }

            var filledSlots = equipment.FillsSlotsWhenEquippedIn(equipmentSlot).ToArray();
            foreach (var filledSlot in filledSlots) Remove(character, filledSlot);
            
            character.EquipmentService.Equip(equipment, filledSlots);
            equipment.Equip(character, equipmentSlot);

            if (equipment.EquipmentModel is { } equipmentModel)
                _equipmentModelController.Equip(character, equipmentModel, equipmentSlot);
        }

        public void Remove(Character character, EquipmentSlot equippedSlot)
        {
            var equipment = GetEquipmentForSlot(character, equippedSlot);
            if (equipment is null) return;

            character.EquipmentService.Remove(equippedSlot);
            equipment.Unequip(character, equippedSlot);

            if (equipment.EquipmentModel is { } equipmentModel)
                _equipmentModelController.Remove(character, equipmentModel);
        }

        public IEquipment? GetEquipmentForSlot(Character character, EquipmentSlot equipmentSlot)
        {
            return character.EquipmentService.GetEquipmentForSlot(equipmentSlot);
        }

        private bool IsEligibleSlot(IEquipment equipment, EquipmentSlot equipmentSlot)
        {
            return equipment.EligibleSlots.Contains(equipmentSlot);
        }
    }
}