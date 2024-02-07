#nullable enable

using Runtime.Abstractions.Spells;

namespace Runtime.Abstractions.Controller
{
    public interface ISpellBookController
    {
        bool KnowsSpell(Character caster, SpellId spellId);
    }
}