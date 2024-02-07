#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IAutoAttackingController
    {
        void SetAutoAttacking(Character character, bool state);

        AutoAttackingState ResolveAutoAttackingState(Character character);
        void ExecuteAutoAttackingState(Character character, AutoAttackingState autoAttackingState);
    }
}