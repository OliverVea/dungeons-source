# nullable enable
using System;

namespace Runtime.Abstractions.Models
{
    public interface IEffect
    {
        Character Target { get; }
        Character Source { get; }
        DuplicateEffectBehavior DuplicateEffectBehavior { get; }
        
        TimeSpan TimeSinceApplication { get; }
        TimeSpan? Duration { get; }
        
        void Apply();
        void Remove();
        void Remove(Character remover);
    }
}