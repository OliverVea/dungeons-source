#nullable enable

using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;

namespace Runtime.Abstractions.Factories
{
    public interface ISpellFactory
    {
         ISpell CreateSpell(SpellId spellId);
    }
}