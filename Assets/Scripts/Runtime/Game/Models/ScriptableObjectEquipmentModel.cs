#nullable enable

using Runtime.Abstractions.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Game.Models
{
    [CreateAssetMenu(menuName = "Items/Equipment Model")]
    public class ScriptableObjectEquipmentModel : ScriptableObject, IEquipmentModel
    {
        [SerializeField, Required] private GameObject _equipmentModel = null!;
        public GameObject EquipmentModel => _equipmentModel;
    }
}