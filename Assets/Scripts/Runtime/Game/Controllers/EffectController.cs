#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Controllers
{
    public class EffectController : IEffectController
    {
        private readonly DiContainer _diContainer;

        public EffectController(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void ApplyEffect(IEffect effect)
        {
            _diContainer.Inject(effect);
            EnforceDuplicateEffectBehavior(effect);
            effect.Target.EffectService.ApplyEffect(effect);
        }

        private void EnforceDuplicateEffectBehavior(IEffect effect)
        {
            switch (effect.DuplicateEffectBehavior)
            {
                case DuplicateEffectBehavior.KeepLatestForEachSource:
                    RemoveDuplicatesFromSameSource(effect);
                    break;
                case DuplicateEffectBehavior.KeepLatest:
                    RemoveDuplicates(effect);
                    break;
                case DuplicateEffectBehavior.KeepAll:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RemoveDuplicates(IEffect effect)
        {
            var toRemove = effect.Target.EffectService.ListEffects()
                .Where(x => IsSameEffect(x, effect));

            RemoveEffects(toRemove, effect.Source);
        }

        private static bool IsSameEffect(IEffect lhs, IEffect rhs)
        {
            return lhs.GetType() == rhs.GetType();
        }

        private void RemoveDuplicatesFromSameSource(IEffect effect)
        {
            var toRemove = effect.Target.EffectService.ListEffects()
                .Where(x => IsSameEffect(x, effect) && x.Source == effect.Source);

            RemoveEffects(toRemove, effect.Source);
        }

        private void RemoveEffects(IEnumerable<IEffect> effects, Character remover)
        {
            foreach (var effect in effects) RemoveEffect(effect, remover);
        }

        public void RemoveEffect(IEffect effect)
        {
            effect.Target.EffectService.RemoveEffect(effect);
        }

        public void RemoveEffect(IEffect effect, Character remover)
        {
            effect.Target.EffectService.RemoveEffect(effect, remover);
        }

        public bool HasExpired(IEffect effect)
        {
            return effect.TimeSinceApplication > effect.Duration;
        }

        public void ExpireEffect(IEffect effect)
        {
            RemoveEffect(effect);
        }

        public void TickEffect(IEffect effect)
        {
            if (HasExpired(effect)) ExpireEffect(effect);

            if (effect is ITickingEffect tickingEffect) TickTickingEffect(tickingEffect);
        }

        private void TickTickingEffect(ITickingEffect tickingEffect)
        {
            if (!ShouldTick(tickingEffect)) return;

            tickingEffect.Tick();
        }

        private bool ShouldTick(ITickingEffect tickingEffect)
        {
            return tickingEffect.TimeSinceTick > tickingEffect.TickPeriod;
        }
    }
}