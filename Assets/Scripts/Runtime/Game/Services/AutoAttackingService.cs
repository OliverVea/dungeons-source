# nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Services
{
    public class AutoAttackingService : ITickable, IAutoAttackingService
    {
        private readonly ITimer _timer;
        private readonly Character _character;
        private readonly IAutoAttackingController _autoAttackingController;

        public AutoAttackingService(
            ITimer timer,
            Character character,
            IAutoAttackingController autoAttackingController)
        {
            _timer = timer;
            _character = character;
            _autoAttackingController = autoAttackingController;
        }
        
        public bool AutoAttacking { get; private set; }
        public AutoAttackingState AutoAttackingState { get; private set; } = AutoAttackingState.None;
        
        public void SetAutoAttacking(bool shouldAutoAttack)
        {
            if (shouldAutoAttack) _timer.Reset();
            AutoAttacking = shouldAutoAttack;
        }

        public bool IsReadyToSwing()
        {
            return _timer.Check(Constants.Combat.MeleeSwingRecovery);
        }

        public void ResetSwingTimer()
        {
            _timer.Reset();
        }

        public void Tick()
        {
            var newState = _autoAttackingController.ResolveAutoAttackingState(_character);

            if (newState == AutoAttackingState) return;

            _autoAttackingController.ExecuteAutoAttackingState(_character, newState);
            
            AutoAttackingState = newState;
        }
    }
}