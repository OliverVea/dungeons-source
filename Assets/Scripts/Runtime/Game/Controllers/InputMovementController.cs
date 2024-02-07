#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Controllers
{
    public class InputMovementController : IInputMovementController
    {
        private readonly IAnimationController _animationController;
        private readonly IPlayerCharacterManager _playerCharacterManager;
        private readonly IRaycastHelper _raycastHelper;
        
        public InputMovementController(IPlayerCharacterManager playerCharacterManager,
            IAnimationController animationController,
            IRaycastHelper raycastHelper)
        {
            _playerCharacterManager = playerCharacterManager;
            _animationController = animationController;
            _raycastHelper = raycastHelper;
        }

        public bool ShouldEvaluate()
        {
            return _playerCharacterManager.PlayerCharacter is not null;
        }

        public void SetDirection(Vector3 direction)
        {
            if (_playerCharacterManager.PlayerCharacter is not {} playerCharacter) return;
            playerCharacter.InputMovementService.SetDirection(direction.x, direction.z);
        }

        public void Jump()
        {
            if (_playerCharacterManager.PlayerCharacter is not {} playerCharacter) return;

            if (!IsGrounded(playerCharacter)) return;
            
            playerCharacter.InputMovementService.Jump();
            _animationController.Trigger(playerCharacter, AnimationName.Jump);
        }

        public bool IsGrounded(Character character)
        {
            return _raycastHelper.RayCastDown(character.Feet, Constants.Movement.FloorDistance, LayerName.Ground);
        }
    }
}