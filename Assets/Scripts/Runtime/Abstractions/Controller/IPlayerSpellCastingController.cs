#nullable enable
using Runtime.Abstractions.Spells;

namespace Runtime.Abstractions.Controller
{
    public interface IPlayerSpellCastingController
    {
        void CastSpell(SpellId spellId);
    }
}