#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Managers
{
    public class MouseOverManager : IMouseOverManager
    {
        public IMouseComponent? MouseOver { get; private set; }

        public bool IsMouseOver(IMouseComponent? mouseOver)
        {
            return mouseOver == MouseOver;
        }

        public void SetMouseOver(IMouseComponent? mouseOver)
        {
            MouseOver = mouseOver;
        }
    }
}