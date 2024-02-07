#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Models
{
    public abstract class BaseScriptableObjectInventoryItem : ScriptableObject, IInventoryItem
    {
        public abstract string Name { get; }
        public abstract void Use(Character user);
    }
}