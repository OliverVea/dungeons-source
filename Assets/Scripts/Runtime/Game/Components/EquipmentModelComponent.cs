#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Game.Components
{
    public class EquipmentModelComponent : MonoBehaviour, IEquipmentModelComponent
    {
        [SerializeField] private EquipmentSlotTransform[] _equipmentSlotTransforms = Array.Empty<EquipmentSlotTransform>();
        
        public Transform? GetTransform(EquipmentSlot equipmentSlot)
        {
            foreach (var equipmentSlotTransform in _equipmentSlotTransforms)
                if (equipmentSlot == equipmentSlotTransform._equipmentSlot)
                    return equipmentSlotTransform._transform;

            return null;
        }

        [Serializable]
        private class EquipmentSlotTransform
        {
            [Required] public EquipmentSlot _equipmentSlot;
            [Required] public Transform _transform = null!;
        }
    }
}