#nullable enable
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;

namespace Runtime.Abstractions.Controller
{
    public interface ISpellCastingController
    {
        ISpell CreateSpell(SpellId spellId);
        void CastSpell(Character caster, SpellId spellId);
        void CastSpell(Character caster, ISpell spell);
        bool CanCastSpell(Character caster, SpellId spellId);
        bool CanCastSpell(Character caster, ISpell spell);
    }
}