#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IMovementController
    {
        float GetCurrentSpeed(Character character);
        float GetCurrentEffectiveMovementModifier(Character character);
        bool IsMoving(Character character);
    }
}