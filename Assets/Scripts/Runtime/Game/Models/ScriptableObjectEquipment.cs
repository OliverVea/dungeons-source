#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Models
{
    [CreateAssetMenu(menuName = "Items/Equipment")]
    public class ScriptableObjectEquipment : ScriptableObject, IInventoryItem, IEquipment
    {
        [Inject] private readonly ILogger _logger = null!;
        [Inject] private readonly IEquipmentController _equipmentController = null!;
        [Inject] private readonly IInventoryController _inventoryController = null!;

        [SerializeField] private string _name = string.Empty;
        [SerializeField] private EquipmentSlot[] _eligibleSlots = Array.Empty<EquipmentSlot>();
        [SerializeField] private EquipmentSlot[] _fillsSlots = Array.Empty<EquipmentSlot>();
        [SerializeField] private ScriptableObjectEquipmentModel? _equipmentModel;

        public string Name => _name;
        public IEnumerable<EquipmentSlot> EligibleSlots => _eligibleSlots;
        public IEnumerable<EquipmentSlot> FillsSlotsWhenEquippedIn(EquipmentSlot equippedSlot) => _fillsSlots;
        public IEquipmentModel? EquipmentModel => _equipmentModel;

        public void Use(Character user)
        {
            if (!_eligibleSlots.Any()) return;

            var slot = _eligibleSlots.First();
            
            _equipmentController.Equip(user, this, slot);
        }

        public void Equip(Character character, EquipmentSlot equipmentSlot)
        {
            _logger.Log($"{character} equipped {Name} in {equipmentSlot}");
            _inventoryController.RemoveItem(character, this);
        }

        public void Unequip(Character character, EquipmentSlot equipmentSlot)
        {
            _logger.Log($"{character} unequipped {Name} from {equipmentSlot}");
            _inventoryController.AddItem(character, this);
        }
    }
}