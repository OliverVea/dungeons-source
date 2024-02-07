#nullable enable

using Runtime.Abstractions;

namespace Runtime.Game.Effects
{
    public class DamageColorEffect : BaseColorEffect
    {
        public DamageColorEffect(Character source, Character target) : base(source, target, new ColorModifier.Damage())
        {
        }
    }
}