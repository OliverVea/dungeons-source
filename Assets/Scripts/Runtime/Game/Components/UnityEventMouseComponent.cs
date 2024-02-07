#nullable enable

using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Runtime.Game.Components
{
    public class UnityEventMouseComponent : MouseComponentBase
    {
        [Inject] private readonly IPlayerCharacterManager _playerCharacterManager = null!;
        [Inject] private readonly IRangeHelper _rangeHelper = null!;
        
        [SerializeField] private float _range = 2.5f;
        
        [SerializeField] private UnityEvent _enter = new();
        [SerializeField] private UnityEvent _exit = new();
        [SerializeField] private UnityEvent _leftClick = new();
        [SerializeField] private UnityEvent _rightClick = new();
        [SerializeField] private UnityEvent _middleClick = new();
        
        public override void Enter()
        {
            if (enabled) _enter.Invoke();
        }

        public override void Exit()
        {
            if (enabled) _exit.Invoke();
        }

        public override void LeftClick()
        {
            if (enabled && PlayerIsInRange()) _leftClick.Invoke();
        }
        
        public override void RightClick()
        {
            if (enabled && PlayerIsInRange()) _rightClick.Invoke();
        }
        
        public override void MiddleClick()
        {
            if (enabled && PlayerIsInRange()) _middleClick.Invoke();
        }

        private bool PlayerIsInRange()
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return false;

            return _rangeHelper.IsInRange(playerCharacter, transform.position, _range);
        }
    }
}