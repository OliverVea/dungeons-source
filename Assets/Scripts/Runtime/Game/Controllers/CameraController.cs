#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using UnityEngine;

namespace Runtime.Game.Controllers
{
    public class CameraController : ICameraController
    {
        private readonly ICameraService _cameraService;
        private readonly IPlayerCharacterManager _playerCharacterManager;

        public CameraController(ICameraService cameraService,
            IPlayerCharacterManager playerCharacterManager)
        {
            _cameraService = cameraService;
            _playerCharacterManager = playerCharacterManager;
        }

        public void Pan(float change)
        {
            _cameraService.CameraOffset.LeftRightAngle += change;

            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return;

            var movementRotation = GetMovementRotation();
            playerCharacter.InputMovementService.SetMovementRotation(movementRotation);
        }

        public void Zoom(float change)
        {
            var distance = _cameraService.CameraOffset.Distance + change;
            _cameraService.CameraOffset.Distance = Math.Clamp(distance, 0, Constants.Camera.MaxDistance);
        }

        public Ray GetRay(Vector2 mousePosition)
        {
            return _cameraService.Camera.ScreenPointToRay(mousePosition);
        }

        private Quaternion GetMovementRotation()
        {
            return Quaternion.AngleAxis(_cameraService.CameraOffset.LeftRightAngle, Vector3.up);
        }
    }
}