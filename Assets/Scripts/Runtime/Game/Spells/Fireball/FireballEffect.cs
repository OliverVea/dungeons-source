#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Spells.Fireball
{
    public class FireballEffect : ITickingEffect
    {
        [Inject] private readonly ITimeManager _timeManager = null!;
        [Inject] private readonly IHealthController _healthController = null!;
        
        public Character Target { get; }
        public Character Source { get; }
        
        public DuplicateEffectBehavior DuplicateEffectBehavior => FireballStats.DuplicateEffectBehavior;
        public TimeSpan? Duration => FireballStats.EffectDuration;

        public TimeSpan TickPeriod => FireballStats.TickPeriod;
        public TimeSpan TimeSinceApplication => _timeManager.UtcNow - ApplicationTime;
        public TimeSpan TimeSinceTick => _timeManager.UtcNow - TickTime;

        private DateTimeOffset ApplicationTime { get; set; }
        private DateTimeOffset TickTime { get; set; }
        
        public FireballEffect(Character source, Character target)
        {
            Target = target;
            Source = source;
        }
        
        public void Apply()
        {
            ApplicationTime = _timeManager.UtcNow;
        }

        public void Remove()
        {
        }

        public void Remove(Character remover)
        {
            Remove();
        }

        public void Tick()
        {
            TickTime = _timeManager.UtcNow;
            _healthController.DoDamage(Source, Target, FireballStats.TickDamage);
        }
    }
}