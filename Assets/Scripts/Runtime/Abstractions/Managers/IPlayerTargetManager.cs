#nullable enable

namespace Runtime.Abstractions.Managers
{
    public interface IPlayerTargetManager
    {
        Character? PlayerTarget { get; }
        void SetPlayerTarget(Character newTarget);
        void ClearPlayerTarget();
    }
}