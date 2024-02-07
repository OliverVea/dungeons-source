#nullable enable

using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Abstractions
{
    public interface IEquipmentModelComponent
    {
        Transform? GetTransform(EquipmentSlot equipmentSlot);
    }
}