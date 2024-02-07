# nullable enable

using UnityEngine;

namespace Runtime.Abstractions
{
    public interface INavMeshMovementService
    {
        float CurrentSpeed { get; }
        bool NavigationEnabled();
        void SetDestination(Vector3 destination);
        void SetNavigationEnabled(bool state);
    }
}