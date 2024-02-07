#nullable enable

namespace Runtime.Abstractions.Spells
{
    public enum SpellStatus
    {
        Uncast,
        Casting,
        Finished,
        Cancelled,
        Invalid
    }
}