#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Managers
{
    public interface IMouseComponentManager
    {
        IMouseComponent? Get(Collider collider);
        void Register(IMouseComponent component, Collider collider);
        void Unregister(Collider collider);
    }
}