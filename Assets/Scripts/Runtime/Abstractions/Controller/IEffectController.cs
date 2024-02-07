#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IEffectController
    {
        public void ApplyEffect(IEffect effect);
        public void RemoveEffect(IEffect effect);
        public void RemoveEffect(IEffect effect, Character remover);
        bool HasExpired(IEffect effect);
        void ExpireEffect(IEffect effect);
        void TickEffect(IEffect effect);
    }
}