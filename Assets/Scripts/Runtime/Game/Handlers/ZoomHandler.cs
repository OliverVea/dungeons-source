#nullable enable

using System;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Handlers
{
    public class ZoomHandler : IInitializable, IDisposable, ITickable
    {
        private const float ZoomSpeed = 0.25f;
        
        private readonly ITimeManager _timeManager;
        private readonly InputWrapper _inputWrapper;
        private readonly ICameraController _cameraController;

        public ZoomHandler(InputWrapper inputWrapper, ICameraController cameraController, ITimeManager timeManager)
        {
            _inputWrapper = inputWrapper;
            _cameraController = cameraController;
            _timeManager = timeManager;
        }

        public void Initialize()
        {
            _inputWrapper.Gameplay.Zoom.Enable();
        }

        public void Dispose()
        {
            _inputWrapper.Dispose();
        }

        public void Tick()
        {
            if (!Application.isFocused) return;
            
            var input = _inputWrapper.Gameplay.Zoom.ReadValue<float>();
            var change = input * _timeManager.DeltaTime * ZoomSpeed;
            _cameraController.Zoom(change);
        }
    }
}