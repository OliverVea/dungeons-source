#nullable enable

namespace Runtime.Abstractions.Helpers
{
    public interface ILineOfSightHelper
    {
        bool HasLineOfSight(Character source, Character target);
    }
}