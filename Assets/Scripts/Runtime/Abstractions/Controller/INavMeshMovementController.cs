#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Controller
{
    public interface INavMeshMovementController
    {
        bool NavigationEnabled(Character character);
        void SetNavigationEnabled(Character character, bool state);
        void SetDestination(Character character, Vector3 destination);
        float GetCurrentSpeed(Character character);
    }
}