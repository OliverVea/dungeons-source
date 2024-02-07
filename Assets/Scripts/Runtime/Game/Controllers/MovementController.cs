#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;

namespace Runtime.Game.Controllers
{
    public class MovementController : IMovementController
    {
        private readonly INavMeshMovementController _navMeshMovementController;

        public MovementController(INavMeshMovementController navMeshMovementController)
        {
            _navMeshMovementController = navMeshMovementController;
        }

        public float GetCurrentEffectiveMovementModifier(Character character)
        {
            var currentSpeed = GetCurrentSpeed(character);
            
            return currentSpeed / character.MovementService.BaseSpeed;
        }

        public bool IsMoving(Character character)
        {
            return GetCurrentSpeed(character) > 0.01f;
        }

        public float GetCurrentSpeed(Character character)
        {
            var usesNavMeshMovement = _navMeshMovementController.NavigationEnabled(character);
            
            return usesNavMeshMovement ? _navMeshMovementController.GetCurrentSpeed(character) : character.MovementService.CurrentSpeed;
        }
    }
}