#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IMouseController
    {
        void MouseOver(IMouseComponent? hit);
        void LeftClick();
        void RightClick();
        void MiddleClick();
    }
}