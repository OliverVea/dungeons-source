#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IStatsController
    {
        float GetHealth(Character character);
        float GetHealthPerSecond(Character character);
        float GetMana(Character character);
        float GetManaPerSecond(Character character);
        float GetSpellPower(Character character);
    }
}