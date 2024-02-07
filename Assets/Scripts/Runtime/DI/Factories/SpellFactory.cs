#nullable enable

using System;
using Runtime.Abstractions.Factories;
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;
using Runtime.Game.Spells.Fireball;
using Zenject;

namespace Runtime.DI.Factories
{
    public class SpellFactory : ISpellFactory
    {
        private readonly DiContainer _diContainer;

        public SpellFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public ISpell CreateSpell(SpellId spellId)
        {
            return spellId switch
            {
                SpellId.Fireball => _diContainer.Resolve<Fireball>(),
                _ => throw new ArgumentOutOfRangeException(nameof(spellId), spellId, null)
            };
        }
    }
}