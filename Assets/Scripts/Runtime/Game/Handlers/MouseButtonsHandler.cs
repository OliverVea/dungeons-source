#nullable enable

using System;
using Runtime.Abstractions.Controller;
using Runtime.Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Runtime.Game.Handlers
{
    public class MouseButtonsHandler : IInitializable, IDisposable
    {
        private readonly InputWrapper _inputWrapper;
        private readonly IMouseController _mouseController;

        public MouseButtonsHandler(
            InputWrapper inputWrapper,
            IMouseController mouseController)
        {
            _inputWrapper = inputWrapper;
            _mouseController = mouseController;
        }

        public void Initialize()
        {
            _inputWrapper.Mouse.LeftClick.Enable();
            _inputWrapper.Mouse.RightClick.Enable();
            _inputWrapper.Mouse.MiddleClick.Enable();
            
            _inputWrapper.Mouse.LeftClick.performed += LeftClick;
            _inputWrapper.Mouse.RightClick.performed += RightClick;
            _inputWrapper.Mouse.MiddleClick.performed += MiddleClick;
        }

        public void Dispose()
        {
            _inputWrapper.Mouse.LeftClick.Disable();
            _inputWrapper.Mouse.RightClick.Disable();
            _inputWrapper.Mouse.MiddleClick.Disable();
            
            _inputWrapper.Mouse.LeftClick.performed -= LeftClick;
            _inputWrapper.Mouse.RightClick.performed -= RightClick;
            _inputWrapper.Mouse.MiddleClick.performed -= MiddleClick;
        }

        private void LeftClick(InputAction.CallbackContext callbackContext)
        {
            if (!Application.isFocused) return;
            _mouseController.LeftClick();
        }

        private void RightClick(InputAction.CallbackContext callbackContext)
        {
            if (!Application.isFocused) return;
            _mouseController.RightClick();
        }

        private void MiddleClick(InputAction.CallbackContext callbackContext)
        {
            if (!Application.isFocused) return;
            _mouseController.MiddleClick();
        }
    }
}