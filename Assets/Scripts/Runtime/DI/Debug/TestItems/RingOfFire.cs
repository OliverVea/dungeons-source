#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Runtime.Game.Spells.Fireball;
using UnityEngine;
using Zenject;

namespace Runtime.DI.Debug.TestItems
{
    [CreateAssetMenu(menuName = "Items/Test/Ring of Fire")]
    public class RingOfFire : ScriptableObject, IInventoryItem, IEquipment
    {
        [Inject] private readonly IInventoryController _inventoryController = null!;
        [Inject] private readonly IEquipmentController _equipmentController = null!;
        [Inject] private readonly IEffectController _effectController = null!;
        
        private static readonly HashSet<EquipmentSlot> RingEligibleSlots = new()
            { EquipmentSlot.RingLeft, EquipmentSlot.RingRight };

        private IEffect? _effect;
        
        public string Name => "Ring of Fire";
        public IEquipmentModel? EquipmentModel => null;
        public IEnumerable<EquipmentSlot> EligibleSlots => RingEligibleSlots;

        public void Use(Character user)
        {
            var slot = RingEligibleSlots.First();
            
            _equipmentController.Equip(user, this, slot);
        }

        public IEnumerable<EquipmentSlot> FillsSlotsWhenEquippedIn(EquipmentSlot equippedSlot)
        {
            return new[] { equippedSlot };
        }

        public void Equip(Character character, EquipmentSlot equipmentSlot)
        {
            _inventoryController.RemoveItem(character, this);

            _effect = new FireballEffect(character, character);
            _effectController.ApplyEffect(_effect);
        }

        public void Unequip(Character character, EquipmentSlot equipmentSlot)
        {
            _inventoryController.AddItem(character, this);

            if (_effect is null) return;
            
            _effectController.RemoveEffect(_effect);
            _effect = null;
        }
    }
}