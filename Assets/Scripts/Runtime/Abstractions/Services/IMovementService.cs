#nullable enable

namespace Runtime.Abstractions
{
    public interface IMovementService
    {
        float Modifier { get; }
        float BaseSpeed { get; }
        float Speed { get; }
        float CurrentSpeed { get; }
        
        void AddModifier(MovementModifier modifier);
        void RemoveModifier(MovementModifier modifier);
    }
}