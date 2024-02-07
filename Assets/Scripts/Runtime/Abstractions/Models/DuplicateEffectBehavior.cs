# nullable enable

namespace Runtime.Abstractions.Models
{
    public enum DuplicateEffectBehavior
    {
        KeepAll,
        KeepLatestForEachSource,
        KeepLatest,
    }
}