# nullable enable

namespace Runtime.Abstractions
{
    public interface IManaService
    {
        float Current { get; }
        void SetCurrent(float value);
    }
}