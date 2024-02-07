#nullable enable

namespace Runtime.Abstractions
{
    public interface IMouseComponent
    {
        void Enter();
        void Exit();
        void LeftClick();
        void RightClick();
        void MiddleClick();
    }
}