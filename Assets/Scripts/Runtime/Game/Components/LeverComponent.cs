# nullable enable

using Runtime.Abstractions.Models;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Game.Components
{
    public class LeverComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _shaft = null!;
        [SerializeField] private Angle _angle;
        
        [SerializeField] private UnityEvent _onActivate = new();
        [SerializeField] private UnityEvent _onDeactivate = new();

        private float _currentAngle;
        private bool _currentState;

        [Button]
        public void Switch()
        {
            SetState(!_currentState);
        }

        private void SetState(bool active)
        {
            var targetAngle = active ? _angle._activated : _angle._deactivated;
            _shaft.transform.Rotate(new Vector3(0, 0, 1), targetAngle - _currentAngle);
            _currentAngle = targetAngle;
            _currentState = active;
            
            if (active) _onActivate.Invoke();
            else _onDeactivate.Invoke();
        }
    }
}