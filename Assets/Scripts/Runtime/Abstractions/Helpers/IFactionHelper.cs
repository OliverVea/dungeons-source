#nullable enable

namespace Runtime.Abstractions.Helpers
{
    public interface IFactionHelper
    {
        bool AreEnemies(Character character, Character target);
        bool SameFaction(Character character, Character target);
    }
}