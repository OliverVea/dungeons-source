#nullable enable

using BehaviorDesigner.Runtime.Tasks;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Zenject;

namespace Runtime.Game.Tasks.Actions
{
    public class SetTargetFromThreat : Action
    {
        [Inject] private readonly Character _character = null!;
        [Inject] private readonly IThreatController _threatController = null!;
        [Inject] private readonly ITargetController _targetController = null!;
        [Inject] private readonly IAutoAttackingController _autoAttackingController = null!;

        public override TaskStatus OnUpdate()
        {
            var target = _threatController.GetTargetFromThreat(_character);
            var hasTarget = target is not null;
            
            _targetController.SetTarget(_character, target);
            _autoAttackingController.SetAutoAttacking(_character, hasTarget);

            return hasTarget ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}