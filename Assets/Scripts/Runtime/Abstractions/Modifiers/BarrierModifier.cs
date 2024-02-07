# nullable enable

namespace Runtime.Abstractions
{
    public abstract class BarrierModifier
    {
        /// <summary>
        /// Does damage to the barrier.
        /// </summary>
        /// <param name="source">The damage source.</param>
        /// <param name="damage">The amount of damage dome to the recipient.</param>
        /// <returns>The remaining damage, if any.</returns>
        public abstract float DoDamage(Character source, float damage);
    }
}