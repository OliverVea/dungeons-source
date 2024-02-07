#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IDeathController
    {
        void Kill(Character character);
        void DeathCleanup(Character character);
    }
}