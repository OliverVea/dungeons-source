# nullable enable

using System;

namespace Runtime.Abstractions.Managers
{
    public interface ITimeManager
    {
        float Time { get; }
        float DeltaTime { get; }
        DateTimeOffset UtcNow { get; }
    }
}