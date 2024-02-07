#nullable enable

namespace Runtime.Abstractions.Managers
{
    public interface IMouseOverManager
    {
        IMouseComponent? MouseOver { get; }
        bool IsMouseOver(IMouseComponent? mouseOver);
        void SetMouseOver(IMouseComponent? mouseOver);
    }
}