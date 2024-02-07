# nullable enable

using System;
using Runtime.Abstractions.Spells;

namespace Runtime.Abstractions.Models
{
    public interface ISpell
    {
        SpellId SpellId { get; }
        string Name { get; }
        TimeSpan Cooldown { get; }
        SpellStatus SpellStatus { get; }
        void Cast(Character caster);
        bool CanCastSpell(Character caster);
    }
}