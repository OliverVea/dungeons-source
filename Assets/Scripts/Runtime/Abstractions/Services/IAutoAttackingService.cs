#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IAutoAttackingService
    {
        bool AutoAttacking { get; }
        AutoAttackingState AutoAttackingState { get; }
        void SetAutoAttacking(bool shouldAutoAttack);
        
        bool IsReadyToSwing();
        void ResetSwingTimer();
    }
}