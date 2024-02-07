# nullable enable

namespace Runtime.Abstractions.Models
{
    public interface ITimer
    {
        void Reset();
        bool Check(float interval);
    }
}