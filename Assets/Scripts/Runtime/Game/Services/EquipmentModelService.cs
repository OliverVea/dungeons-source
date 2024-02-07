#nullable enable

using System.Collections.Generic;
using ModestTree;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Runtime.Game.Services
{
    public class EquipmentModelService : IEquipmentModelService
    {
        [Inject] private readonly IEquipmentModelComponent _equipmentModelComponent = null!;
        
        private readonly Dictionary<IEquipmentModel, GameObject> _equippedModels = new();
        
        public void Equip(IEquipmentModel equipmentModel, EquipmentSlot equipmentSlot)
        {
            var transform = _equipmentModelComponent.GetTransform(equipmentSlot);
            if (transform is null) return;

            var gameObject = Object.Instantiate(equipmentModel.EquipmentModel, transform);
            _equippedModels.Add(equipmentModel, gameObject);
        }

        public void Remove(IEquipmentModel equipmentModel)
        {
            var gameObject = _equippedModels.GetValueAndRemove(equipmentModel);
            Object.Destroy(gameObject);
        }
    }
}