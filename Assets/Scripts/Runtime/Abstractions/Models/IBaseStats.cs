#nullable enable

namespace Runtime.Abstractions.Models
{
    public interface IBaseStats
    {
        float Health { get; }
        float Mana { get; }
        float ManaPerSecond { get; }
        float SpellPower { get; }
    }
}