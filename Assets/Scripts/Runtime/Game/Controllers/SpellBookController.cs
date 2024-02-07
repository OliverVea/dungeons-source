#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Spells;

namespace Runtime.Game.Controllers
{
    public class SpellBookController : ISpellBookController
    {
        public bool KnowsSpell(Character caster, SpellId spellId)
        {
            return caster.SpellBook.Contains(spellId);
        }
    }
}