using Runtime.Abstractions.Spells;

namespace Runtime.Abstractions.Models
{
    public interface ISpellBook
    {
        SpellId[] Spells { get; }
        bool Contains(SpellId spellId);
    }
}