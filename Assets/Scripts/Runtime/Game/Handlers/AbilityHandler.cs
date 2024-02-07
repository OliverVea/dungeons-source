#nullable enable

using System;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Spells;
using Runtime.Game.Input;
using UnityEngine.InputSystem;
using Zenject;

namespace Runtime.Game.Handlers
{
    public class AbilityHandler : IInitializable, IDisposable
    {
        private readonly InputWrapper _inputWrapper;
        private readonly IPlayerSpellCastingController _playerSpellCastingController;

        public AbilityHandler(InputWrapper inputWrapper,
            IPlayerSpellCastingController playerSpellCastingController)
        {
            _inputWrapper = inputWrapper;
            _playerSpellCastingController = playerSpellCastingController;
        }
        
        public void Initialize()
        {
            _inputWrapper.Gameplay.Ability1.performed += OnAbilityPerformed;
            _inputWrapper.Gameplay.Ability1.Enable();
        }

        public void Dispose()
        {
            _inputWrapper.Gameplay.Ability1.performed -= OnAbilityPerformed;
            _inputWrapper.Gameplay.Ability1.Disable();
        }

        private void OnAbilityPerformed(InputAction.CallbackContext callbackContext)
        {
            _playerSpellCastingController.CastSpell(SpellId.Fireball);
        }
    }
}