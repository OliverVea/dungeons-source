#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Controllers
{
    public class AutoAttackingController : IAutoAttackingController
    {
        private readonly IFactionHelper _factionHelper;
        private readonly IRangeHelper _rangeHelper;
        private readonly IConcentrationController _concentrationController;
        private readonly ICoroutineManager _coroutineManager;
        private readonly ITargetController _targetController;
        private readonly IAnimationController _animationController;
        private readonly IHealthController _healthController;

        public AutoAttackingController(
            ITargetController targetController,
            IFactionHelper factionHelper,
            IRangeHelper rangeHelper,
            IAnimationController animationController,
            ICoroutineManager coroutineManager,
            IHealthController healthController,
            IConcentrationController concentrationController)
        {
            _targetController = targetController;
            _factionHelper = factionHelper;
            _rangeHelper = rangeHelper;
            _animationController = animationController;
            _coroutineManager = coroutineManager;
            _healthController = healthController;
            _concentrationController = concentrationController;
        }

        public void SetAutoAttacking(Character character, bool state)
        {
            if (character.AutoAttackingService.AutoAttacking == state) return;
            
            character.AutoAttackingService.SetAutoAttacking(state);
        }

        public AutoAttackingState ResolveAutoAttackingState(Character character)
        {
            if (IsNotAttacking(character)) return AutoAttackingState.NotAttacking;
            if (CannotSwing(character)) return AutoAttackingState.PreparingToSwing;
            return AutoAttackingState.Swing;
        }
        
        private bool IsNotAttacking(Character character) => !IsAutoAttacking(character) || InvalidTarget(character);
        private bool IsAutoAttacking(Character character) => character.AutoAttackingService.AutoAttacking;
        
        private bool InvalidTarget(Character character)
        {
            if (_targetController.GetTarget(character) is not { } target) return true;

            var isEnemy = _factionHelper.AreEnemies(character, target);
            if (!isEnemy) return true;
            
            return false;
        }
        
        private bool CannotSwing(Character character)
        {
            var readyToSwing = character.AutoAttackingService.IsReadyToSwing();
            if (!readyToSwing) return true;

            if (_targetController.GetTarget(character) is not {} target) return true;

            var isConcentrating = _concentrationController.IsConcentrating(character);
            if (isConcentrating) return true;
            
            var inRange = _rangeHelper.IsInRange(character, target, Constants.Combat.MeleeRange);
            if (!inRange) return true;
            
            return false;
        }

        public void ExecuteAutoAttackingState(Character character, AutoAttackingState autoAttackingState)
        {
            if (autoAttackingState == AutoAttackingState.Swing) ExecuteSwing(character);
            else if (autoAttackingState == AutoAttackingState.NotAttacking) ExecuteNotAttacking(character);
            else if (autoAttackingState == AutoAttackingState.PreparingToSwing) ExecutePreparingToSwing(character);
            else throw new ArgumentOutOfRangeException();
        }

        private void ExecuteNotAttacking(Character character)
        {
        }

        private void ExecutePreparingToSwing(Character character)
        {
        }

        private void ExecuteSwing(Character character)
        {
            if (_targetController.GetTarget(character) is not { } target) return;
            
            character.AutoAttackingService.ResetSwingTimer();
            _animationController.Trigger(character, AnimationName.Punch);

            _coroutineManager.AddTimedCallback(Constants.Combat.MeleeSwingTime, () =>
            {
                _healthController.DoDamage(character, target, Constants.Combat.MeleeDamage);
            });
        }
    }
}