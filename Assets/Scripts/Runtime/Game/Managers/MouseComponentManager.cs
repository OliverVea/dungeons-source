#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Managers;
using UnityEngine;

namespace Runtime.Game.Managers
{
    public class MouseComponentManager : IMouseComponentManager
    {
        private readonly Dictionary<Collider, IMouseComponent> _lookup = new();

        public IMouseComponent? Get(Collider collider)
        {
            if (_lookup.TryGetValue(collider, out var mouseOverComponent))
            {
                return mouseOverComponent;
            }

            return null;
        }

        public void Register(IMouseComponent component, Collider collider)
        {
            _lookup.Add(collider, component);
        }

        public void Unregister(Collider collider)
        {
            _lookup.Remove(collider);
        }
    }
}