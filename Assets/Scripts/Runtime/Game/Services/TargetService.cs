# nullable enable

using Runtime.Abstractions;

namespace Runtime.Game.Services
{
    public class TargetService : ITargetService
    {
        public Character? Target { get; private set; }

        public void SetTarget(Character? target)
        {
            Target = target;
        }
    }
}