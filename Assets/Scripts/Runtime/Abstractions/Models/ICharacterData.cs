#nullable enable
namespace Runtime.Abstractions.Models
{
    public interface ICharacterData
    {
        string Name { get; }
        Faction Faction { get; }
        IBaseStats BaseStats { get; }
        ISpellBook SpellBook { get; }
        IModelData ModelData { get; }
        IBehaviorData BehaviorData { get; }
    }
}