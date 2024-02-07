#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Effects
{
    public abstract class BaseColorEffect : IEffect
    {
        [Inject] private readonly ITimeManager _timeManager = null!;
        
        public DuplicateEffectBehavior DuplicateEffectBehavior => DuplicateEffectBehavior.KeepLatest;
        public TimeSpan? Duration => TimeSpan.FromSeconds(0.3);
        
        public Character Target { get; }
        public Character Source { get; }
        public TimeSpan TimeSinceApplication => _timeManager.UtcNow - ApplicationTime;
        
        private DateTimeOffset ApplicationTime { get; set; }
        
        private readonly ColorModifier _colorModifier;

        protected BaseColorEffect(Character source, Character target, ColorModifier colorModifier)
        {
            Source = source;
            Target = target;
            _colorModifier = colorModifier;
        }
        
        public void Apply()
        {
            ApplicationTime = _timeManager.UtcNow;
            Target.ColorService.AddModifier(_colorModifier);
        }

        public void Remove()
        {
            Target.ColorService.RemoveModifier(_colorModifier);
        }

        public void Remove(Character remover) => Remove();
    }
}