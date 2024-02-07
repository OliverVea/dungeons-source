#nullable enable

using System;
using Runtime.Abstractions.Controller;
using Runtime.Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Runtime.Game.Handlers
{
    public class MovementHandler : IInitializable, IDisposable
    {
        private readonly InputWrapper _inputWrapper;
        private readonly IInputMovementController _movementController;
        
        public MovementHandler(InputWrapper inputWrapper,
            IInputMovementController movementController)
        {
            _inputWrapper = inputWrapper;
            _movementController = movementController;
        }
        
        public void Initialize()
        {
            _inputWrapper.Gameplay.Movement.started += OnMovementPerformed;
            _inputWrapper.Gameplay.Movement.canceled += OnMovementPerformed;
            _inputWrapper.Gameplay.Movement.performed += OnMovementPerformed;
            _inputWrapper.Gameplay.Movement.Enable();
        }

        public void Dispose()
        {
            _inputWrapper.Gameplay.Movement.started -= OnMovementPerformed;
            _inputWrapper.Gameplay.Movement.canceled -= OnMovementPerformed;
            _inputWrapper.Gameplay.Movement.performed -= OnMovementPerformed;
            _inputWrapper.Dispose();
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            var movement = Vector3.zero;

            if (context.performed)
            {
                var inputVector = context.ReadValue<Vector2>();
                
                movement.x = inputVector.x;
                movement.z = inputVector.y;
            }

            _movementController.SetDirection(movement);
        }
    }
}