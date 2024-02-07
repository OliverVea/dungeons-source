#nullable enable

using System;

namespace Runtime.Abstractions.Models
{
    public interface ITickingEffect : IEffect
    {
        TimeSpan TickPeriod { get; }
        TimeSpan TimeSinceTick { get; }
        void Tick();
    }
}