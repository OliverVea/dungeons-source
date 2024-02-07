#nullable enable

using BehaviorDesigner.Runtime.Tasks;
using Runtime.Abstractions;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Tasks.Actions
{
    [TaskCategory("Custom")]
    [TaskName("Hello World")]
    public class HelloWorld : Action
    {
        [Inject] private readonly ILogger _logger = null!;
        [Inject] private readonly Character _character = null!;

        public override TaskStatus OnUpdate()
        {
            _logger.Log($"Hello from {_character.Name}!");
            return TaskStatus.Success;
        }
    }
}