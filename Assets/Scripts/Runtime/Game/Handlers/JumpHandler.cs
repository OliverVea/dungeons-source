#nullable enable

using System;
using Runtime.Abstractions.Controller;
using Runtime.Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Runtime.Game.Handlers
{
    public class JumpHandler : IInitializable, IDisposable
    {
        private readonly InputWrapper _inputWrapper;
        private readonly IInputMovementController _movementController;

        public JumpHandler(InputWrapper inputWrapper, IInputMovementController movementController)
        {
            _inputWrapper = inputWrapper;
            _movementController = movementController;
        }

        public void Initialize()
        {
            _inputWrapper.Gameplay.Jump.performed += OnJumpPerformed;
            _inputWrapper.Gameplay.Jump.Enable();
        }

        public void Dispose()
        {
            _inputWrapper.Gameplay.Jump.performed -= OnJumpPerformed;
            _inputWrapper.Gameplay.Jump.Disable();
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (!Application.isFocused) return;
            _movementController.Jump();
        }
    }
}