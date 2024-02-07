#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using UnityEngine;

namespace Runtime.Game.Controllers
{
    public class NavMeshMovementController : INavMeshMovementController
    {
        public bool NavigationEnabled(Character character)
        {
            return character.NavMeshMovementService.NavigationEnabled();
        }

        public void SetNavigationEnabled(Character character, bool state)
        {
            character.NavMeshMovementService.SetNavigationEnabled(state);
        }

        public void SetDestination(Character character, Vector3 destination)
        {
            character.NavMeshMovementService.SetDestination(destination);
            SetNavigationEnabled(character, true);
        }

        public float GetCurrentSpeed(Character character)
        {
            return character.NavMeshMovementService.CurrentSpeed;
        }
    }
}