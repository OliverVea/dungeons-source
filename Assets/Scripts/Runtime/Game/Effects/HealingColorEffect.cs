#nullable enable

using Runtime.Abstractions;

namespace Runtime.Game.Effects
{
    public class HealingColorEffect : BaseColorEffect
    {
        public HealingColorEffect(Character source, Character target) : base(source, target, new ColorModifier.Healing())
        {
        }
    }
}