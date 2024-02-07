#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Services
{
    public class EffectService : ITickable, IEffectService
    {
        private readonly HashSet<IEffect> _effects = new();
        
        private readonly IEffectController _effectController;

        public EffectService(IEffectController effectController)
        {
            _effectController = effectController;
        }

        public void ApplyEffect(IEffect effect)
        {
            _effects.Add(effect);
            effect.Apply();
        }

        public void RemoveEffect(IEffect effect)
        {
            effect.Remove();
            _effects.Remove(effect);
        }

        public void RemoveEffect(IEffect effect, Character remover)
        {
            effect.Remove(remover);
            _effects.Remove(effect);
        }

        public IEnumerable<IEffect> ListEffects()
        {
            return _effects.ToArray();
        }

        public void Tick()
        {
            var effects = _effects.ToArray();
            foreach (var effect in effects) _effectController.TickEffect(effect);
        }
    }
}