#nullable enable

using System;
using Runtime.Abstractions;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runtime.Game.Services
{
    public class NavMeshMovementService : IInitializable, IFixedTickable, INavMeshMovementService
    {
        private const float SpeedTolerance = 0.02f;
        private const float DestinationTolerance = 0.15f;
        
        private readonly NavMeshAgent _navMeshAgent;
        private readonly IMovementService _movementService;
        private readonly Character _character;

        private Vector3 _destination;

        public NavMeshMovementService(NavMeshAgent navMeshAgent, IMovementService movementService, Character character)
        {
            _navMeshAgent = navMeshAgent;
            _movementService = movementService;
            _character = character;
        }

        public float CurrentSpeed => _navMeshAgent.velocity.magnitude;

        public bool NavigationEnabled()
        {
            var navMeshIsEnabled = _navMeshAgent.isActiveAndEnabled;
            if (!navMeshIsEnabled) return false;

            var navMeshIsReady = _navMeshAgent.isOnNavMesh;
            if (!navMeshIsReady) return false;

            return true;
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }

        public void SetNavigationEnabled(bool state)
        {
            _navMeshAgent.enabled = state;
        }

        public void Initialize()
        {
            _destination = _character.Transform.position;
        }

        public void FixedTick()
        {
            if (!NavigationEnabled()) return;
            
            SetDestination();
            SetSpeed();
        }

        private void SetDestination()
        {
            var destinationDelta = (_navMeshAgent.destination - _destination).magnitude;
            if (destinationDelta < DestinationTolerance) return;
            
            _navMeshAgent.destination = _destination;
        }

        private void SetSpeed()
        {
            var newSpeed = _movementService.Speed;
            
            var speedDelta = Math.Abs(newSpeed - _navMeshAgent.speed);
            if (speedDelta < SpeedTolerance) return;
            
            _navMeshAgent.speed = newSpeed;
        }
    }
}