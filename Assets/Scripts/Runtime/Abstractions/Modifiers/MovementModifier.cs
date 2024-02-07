# nullable enable

namespace Runtime.Abstractions
{
    public abstract class MovementModifier
    {
        public virtual bool CanMove => true;
        public virtual float SpeedMultiplier => 1f;
    }
}