#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Managers;
using Runtime.Game.Extensions;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Services
{
    public class MovementService : IFixedTickable, IMovementService, IInputMovementService
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly ITimeManager _timeManager;
            
        private readonly HashSet<MovementModifier> _movementModifiers = new();
        
        private const float RotationSpeed = 15f;

        public MovementService(Rigidbody rigidbody, Transform transform, ITimeManager timeManager)
        {
            _rigidbody = rigidbody;
            _transform = transform;
            _timeManager = timeManager;
        }
        
        public Quaternion MovementRotation { get; private set; }
        public Vector3 RelativeDirection { get; private set; }
        public Vector3 AbsoluteDirection => MovementRotation * RelativeDirection;
        public float Modifier => _movementModifiers.Product(x => x.CanMove ? x.SpeedMultiplier : 0);
        public float BaseSpeed => 5f;
        public float Speed => BaseSpeed * Modifier;
        public float CurrentSpeed => _rigidbody.velocity.WithY(0).magnitude;
        
        public void AddModifier(MovementModifier modifier)
        {
            _movementModifiers.Add(modifier);
        }

        public void RemoveModifier(MovementModifier modifier)
        {
            _movementModifiers.Remove(modifier);
        }

        public void SetDirection(float x, float z)
        {
            RelativeDirection = new Vector3(x, 0, z);
        }

        public void SetMovementRotation(Quaternion movementRotation)
        {
            MovementRotation = movementRotation;
        }

        public void Jump()
        {
            var movement = Vector3.up * Constants.Movement.JumpVelocity;
            _rigidbody.AddForce(movement, ForceMode.VelocityChange);
        }

        public void FixedTick()
        {
            var direction = AbsoluteDirection;
            
            if (RelativeDirection.magnitude > 0)
            {
                var currentRotation = _transform.rotation;
                var rotation = Quaternion.LookRotation(direction);
                _transform.rotation = Quaternion.Slerp(currentRotation, rotation, RotationSpeed * _timeManager.DeltaTime);
            }
            
            var velocity = direction.normalized * Speed;
            var delta = velocity - _rigidbody.velocity;
            delta.y = 0;
            _rigidbody.AddForce(delta, ForceMode.VelocityChange);
        }
    }
}