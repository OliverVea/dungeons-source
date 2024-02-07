#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;

namespace Runtime.Game.Controllers
{
    public class ManaController : IManaController
    {
        public bool HasMana(Character character, float amount)
        {
            return character.ManaService.Current >= amount;
        }

        public void Deduct(Character character, float amount)
        {
            var newValue = character.ManaService.Current - amount;
            character.ManaService.SetCurrent(newValue);
        }
    }
}