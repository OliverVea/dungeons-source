# nullable enable

namespace Runtime.Abstractions
{
    public interface IHealthService
    {
        float Current { get; }
        void SetCurrent(float value);
    }
}