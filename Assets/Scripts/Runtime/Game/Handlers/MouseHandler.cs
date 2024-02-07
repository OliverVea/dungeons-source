#nullable enable

using System.Linq;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Handlers
{
    public class MouseHandler : ITickable, IInitializable
    {
        private readonly InputWrapper _inputWrapper;
        private readonly ICameraController _cameraController;
        private readonly IMouseComponentManager _mouseComponentManager;
        private readonly IMouseController _mouseController;

        private readonly RaycastHit[] _raycastHits = new RaycastHit[128];

        public MouseHandler(
            InputWrapper inputWrapper,
            ICameraController cameraController,
            IMouseComponentManager mouseComponentManager,
            IMouseController mouseController)
        {
            _inputWrapper = inputWrapper;
            _cameraController = cameraController;
            _mouseComponentManager = mouseComponentManager;
            _mouseController = mouseController;
        }

        public void Initialize()
        {
            _inputWrapper.Mouse.Position.Enable();
        }
        
        public void Tick()
        {
            if (!Application.isFocused) return;
            
            var mousePosition = _inputWrapper.Mouse.Position.ReadValue<Vector2>();

            var ray = _cameraController.GetRay(mousePosition);

            var hitCount = Physics.RaycastNonAlloc(ray, _raycastHits, float.MaxValue);
            
            var hit = _raycastHits
                .Take(hitCount)
                .OrderBy(x => x.distance)
                .Select(x => _mouseComponentManager.Get(x.collider))
                .FirstOrDefault();

            _mouseController.MouseOver(hit);
        }
    }
}