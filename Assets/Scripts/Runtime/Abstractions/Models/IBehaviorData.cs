#nullable enable
using BehaviorDesigner.Runtime;

namespace Runtime.Abstractions.Models
{
    public interface IBehaviorData
    {
        ExternalBehavior BehaviorTree { get; }
    }
}