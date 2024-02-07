#nullable enable

using System;
using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using UnityEngine.Events;

namespace Runtime.Game.Spells
{
    public abstract class SpellConcentration : IConcentration
    {
        private readonly ITimeManager _timeManager;
        
        public readonly UnityEvent OnStart = new();
        public readonly UnityEvent OnFinish = new();
        public readonly UnityEvent<Character?> OnCancelled = new();

        protected SpellConcentration(ITimeManager timeManager)
        {
            _timeManager = timeManager;
        }

        public abstract string Text { get; }
        public TimeSpan TimeSinceStarted => _timeManager.UtcNow - _startTime;
        private DateTimeOffset _startTime;
        public abstract TimeSpan TotalTime { get; }
        
        protected abstract HashSet<InterruptionSource> InterruptionSources { get; }

        public virtual void Start()
        {
            _startTime = _timeManager.UtcNow;
            OnStart.Invoke();
        }

        public virtual void Finish()
        {
            OnFinish.Invoke();
        }

        public virtual bool Cancel(InterruptionSource interruptionSource)
        {
            var cancelled = CanInterrupt(interruptionSource);
            if (cancelled) OnCancelled.Invoke(null);

            return cancelled;
        }

        public virtual bool Cancel(InterruptionSource interruptionSource, Character source)
        {
            var cancelled = CanInterrupt(interruptionSource);
            if (cancelled) OnCancelled.Invoke(source);

            return cancelled;
        }

        protected virtual bool CanInterrupt(InterruptionSource interruptionSource)
        {
            return InterruptionSources.Contains(interruptionSource);
        }
    }
}