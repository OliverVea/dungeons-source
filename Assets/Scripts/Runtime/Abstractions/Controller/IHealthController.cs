#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IHealthController
    {
        void DoDamage(Character source, Character target, float amount);
        void DoHealing(Character source, Character target, float amount);
    }
}