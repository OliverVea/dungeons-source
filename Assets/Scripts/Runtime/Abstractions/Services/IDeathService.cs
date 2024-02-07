#nullable enable

namespace Runtime.Abstractions
{
    public interface IDeathService
    {
        bool IsDead { get; }
        void Kill();
    }
}