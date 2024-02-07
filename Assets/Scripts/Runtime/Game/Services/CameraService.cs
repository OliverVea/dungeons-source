#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Services
{
    public class CameraService : ILateTickable, ICameraService
    {
        private const float Speed = 0.35f;

        private readonly Camera _camera;
        private readonly Transform _cameraTransform;
        private readonly IPlayerCharacterManager _playerCharacterManager;
        private readonly ICameraOffsetHelper _cameraOffsetHelper;

        private Vector3 _velocity;
        public CameraOffset CameraOffset { get; } = new();

        public CameraService(
            Camera camera,
            IPlayerCharacterManager playerCharacterManager,
            ICameraOffsetHelper cameraOffsetHelper)
        {
            _camera = camera;
            _cameraTransform = camera.transform;
            _playerCharacterManager = playerCharacterManager;
            _cameraOffsetHelper = cameraOffsetHelper;
        }

        public UnityEngine.Camera Camera => _camera;

        private Vector3 GetTargetPosition(Vector3 playerHead)
        {
            var positionOffset = _cameraOffsetHelper.GetPositionOffset(CameraOffset);
            return playerHead + positionOffset;
        }

        private Vector3 GetCameraPosition(Vector3 targetPosition)
        {
            var speed = Mathf.Lerp(0, Speed, CameraOffset.Distance / 5f);
            return Vector3.SmoothDamp(_cameraTransform.position, targetPosition, ref _velocity, speed);
        }
        
        private Quaternion GetCameraRotation(Vector3 playerHead, Vector3 cameraPosition)
        {
            var delta = playerHead - cameraPosition;
            if (delta.magnitude > 0.5f) return Quaternion.LookRotation(delta);

            return Quaternion.AngleAxis(CameraOffset.LeftRightAngle, Vector3.up);
        }

        public void LateTick()
        {
            if (_playerCharacterManager.PlayerCharacter is not { Head: var playerHead }) return;

            var targetPosition = GetTargetPosition(playerHead);
            
            var cameraPosition = GetCameraPosition(targetPosition);
            var cameraRotation = GetCameraRotation(playerHead, cameraPosition);
            
            _cameraTransform.position = cameraPosition;
            _cameraTransform.rotation = cameraRotation;
        }
    }
}