#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IEffectService
    {
        void ApplyEffect(IEffect effect);
        void RemoveEffect(IEffect effect);
        void RemoveEffect(IEffect effect, Character remover);
        IEnumerable<IEffect> ListEffects();
    }
}