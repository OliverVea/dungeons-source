#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Models
{
    [CreateAssetMenu(menuName = "Items/Potion")]
    public class ScriptableObjectInventoryItemPotion : ScriptableObject, IInventoryItem
    {
        [Inject] private readonly IInventoryController _inventoryController = null!;
        [Inject] private readonly IHealthController _healthController = null!;

        [SerializeField] private string _name = string.Empty;
        [SerializeField] private float _healing;

        public string Name => _name;

        public void Use(Character user)
        {
            _healthController.DoHealing(user, user, _healing);
            _inventoryController.RemoveItem(user, this);
        }
    }
}