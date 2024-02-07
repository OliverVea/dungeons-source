#nullable enable

using Runtime.Abstractions.Managers;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Services
{
    public abstract class BaseStatService : ITickable, IInitializable
    {
        private readonly ITimeManager _timeManager;
        
        protected BaseStatService(ITimeManager timeManager)
        {
            _timeManager = timeManager;
        }
        
        protected abstract float Max { get; }
        protected abstract float RegenerationPerSecond { get; }
        protected abstract float InitialValue { get; }
        private float RegenerationForTick => RegenerationPerSecond * _timeManager.DeltaTime;
        
        public float Current { get; private set; }
        
        public void SetCurrent(float value)
        {
            Current = Mathf.Clamp(value, 0, Max);
        }

        public void Tick()
        {
            SetCurrent(Current + RegenerationForTick);
        }

        public void Initialize()
        {
            Current = InitialValue;
        }
    }
}