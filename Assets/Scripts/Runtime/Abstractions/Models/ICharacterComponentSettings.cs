#nullable enable
namespace Runtime.Abstractions.Models
{
    public interface ICharacterComponentSettings
    {
        bool RigidbodyIsKinematic { get; }
        bool BehaviorTreeEnabled { get; }
        bool NavMeshAgentEnabled { get; }
    }
}