# nullable enable

namespace Runtime.Abstractions
{
    public abstract class StatusModifier
    {
        public virtual bool IsImmune => false;
    }
}