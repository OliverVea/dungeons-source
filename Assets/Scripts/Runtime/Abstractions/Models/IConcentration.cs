#nullable enable

using System;

namespace Runtime.Abstractions.Models
{
    public interface IConcentration
    {
        string Text { get; }
        TimeSpan TimeSinceStarted { get; }
        TimeSpan TotalTime { get; }

        void Start();
        void Finish();
        bool Cancel(InterruptionSource interruptionSource);
        bool Cancel(InterruptionSource interruptionSource, Character source);
    }
}