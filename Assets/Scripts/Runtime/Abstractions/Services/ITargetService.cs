# nullable enable

namespace Runtime.Abstractions
{
    public interface ITargetService
    {
        public Character? Target { get; }
        public void SetTarget(Character? target);
    }
}