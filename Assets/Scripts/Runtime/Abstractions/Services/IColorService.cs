# nullable enable

namespace Runtime.Abstractions
{
    public interface IColorService
    {
        void AddModifier(ColorModifier colorModifier);
        void RemoveModifier(ColorModifier colorModifier);
    }
}