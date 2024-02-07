#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IManaController
    {
        bool HasMana(Character character, float amount);
        void Deduct(Character character, float amount);
    }
}