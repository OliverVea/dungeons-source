#nullable enable

using BehaviorDesigner.Runtime.Tasks;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Zenject;

namespace Runtime.Game.Tasks.Actions
{
    public class ChaseTarget : Action
    {
        [Inject] private readonly Character _character = null!;
        [Inject] private readonly ITargetController _targetController = null!;
        [Inject] private readonly INavMeshMovementController _navMeshMovementController = null!;
        
        public override TaskStatus OnUpdate()
        {
            var target = _targetController.GetTarget(_character);
            if (target is null) return TaskStatus.Failure;

            var destination = target.Transform.position;
            _navMeshMovementController.SetDestination(_character, destination);

            return TaskStatus.Success;
        }
    }
}