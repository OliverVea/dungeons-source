# nullable enable

using Runtime.Abstractions.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Game.Components
{
    public class DoorComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _leftDoor = null!;
        [SerializeField] private GameObject _rightDoor = null!;
        [SerializeField] private Angle _angle;
        
        [SerializeField] private float _currentAngle;
        private bool _currentState;

        [Button]
        public void Open()
        {
            SetState(true);
        }

        [Button]
        public void Close()
        {
            SetState(false);
        }

        private void SetState(bool active)
        {
            var targetAngle = active ? _angle._activated : _angle._deactivated;
            var delta = targetAngle - _currentAngle;
            
            _leftDoor.transform.Rotate(Vector3.up, -delta);
            _rightDoor.transform.Rotate(Vector3.up, delta);
            
            _currentAngle = targetAngle;
        }
    }
}