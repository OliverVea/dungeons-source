#nullable enable

using BehaviorDesigner.Runtime.Tasks;

namespace Runtime.Game.Tasks.Conditionals
{
    public abstract class BaseConditional : Conditional
    {
        public bool inverted = false;
        
        /// <summary>
        /// The conditional check. Return false for TaskStatus.Failure and true for TaskStatus.Success.
        /// </summary>
        protected abstract bool Check();
        
        public override TaskStatus OnUpdate()
        {
            var success = Check() != inverted;
            return success ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}