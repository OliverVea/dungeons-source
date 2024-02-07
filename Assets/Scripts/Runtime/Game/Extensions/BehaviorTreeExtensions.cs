#nullable enable

using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Extensions
{
    public static class BehaviorTreeExtensions
    {
        public static void QueueAllTasksForInject(this BehaviorTree tree, DiContainer container)
        {
            tree.CheckForSerialization(true, Application.isPlaying);

            tree.OnBehaviorStart += behavior => InjectIntoBehavior(container, behavior);
        }

        private static void InjectIntoBehavior(DiContainer container, Behavior behavior)
        {
            foreach (var task in behavior.FindTasks<Task>())
            {
                if (task is BehaviorTreeReference referenceTask)
                {
                    InjectIntoExternalTasks(container, referenceTask);
                }

                container.Inject(task);
            }
        }

        private static void InjectIntoExternalTasks(DiContainer container, BehaviorTreeReference referenceTask)
        {
            foreach (var externalBehavior in referenceTask.GetExternalBehaviors())
            {
                externalBehavior.Init();
                var externalTasks = externalBehavior.FindTasks<Task>();
                foreach (var externalTask in externalTasks) container.Inject(externalTask);
            }
        }
    }
}