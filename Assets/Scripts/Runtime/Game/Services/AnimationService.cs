# nullable enable

using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Services
{
    public class AnimationService : IAnimationService, ITickable
    {
        private static readonly int SpeedHash = Animator.StringToHash("speed");
        
        private readonly Animator _animator;
        private readonly Character _character;
        private readonly IMovementController _movementController;
        
        private static readonly Dictionary<AnimationName, int> AnimationHashLookup = new()
        {
            { AnimationName.Jump, Animator.StringToHash("jump")},
            { AnimationName.Punch, Animator.StringToHash("punch")},
            { AnimationName.Cast, Animator.StringToHash("cast")}
        };

        internal AnimationService(Animator animatorProvider,
            IMovementController movementController,
            Character character)
        {
            _animator = animatorProvider;
            _movementController = movementController;
            _character = character;
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(SpeedHash, speed);
        }

        public void Trigger(AnimationName animationName)
        {
            var hash = AnimationHashLookup[animationName];
            _animator.SetTrigger(hash);
        }

        public void Tick()
        {
            var animationSpeed = _movementController.GetCurrentEffectiveMovementModifier(_character);
            SetSpeed(animationSpeed);
        }
    }
}