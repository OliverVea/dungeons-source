#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Controllers
{
    public class MouseController : IMouseController
    {
        private readonly IPlayerTargetManager _playerTargetManager;
        private readonly IMouseOverManager _mouseOverManager;

        public MouseController(IMouseOverManager mouseOverManager,
            IPlayerTargetManager playerTargetManager)
        {
            _mouseOverManager = mouseOverManager;
            _playerTargetManager = playerTargetManager;
        }

        public void MouseOver(IMouseComponent? hit)
        {
            if (_mouseOverManager.IsMouseOver(hit)) return;
            
            _mouseOverManager.MouseOver?.Exit();
            hit?.Enter();

            _mouseOverManager.SetMouseOver(hit);
        }

        public void LeftClick()
        {
            if (_mouseOverManager.MouseOver is { } mouseOver) mouseOver.LeftClick();
            else _playerTargetManager.ClearPlayerTarget();
        }

        public void RightClick()
        {
            if (_mouseOverManager.MouseOver is { } mouseOver) mouseOver.RightClick();
            else _playerTargetManager.ClearPlayerTarget();
        }

        public void MiddleClick()
        {
            if (_mouseOverManager.MouseOver is { } mouseOver) mouseOver.MiddleClick();
            else _playerTargetManager.ClearPlayerTarget();
        }
    }
}