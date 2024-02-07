#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;

namespace Runtime.Game.Controllers
{
    public class TargetController : ITargetController
    {
        public Character? GetTarget(Character character)
        {
            return character.TargetService.Target;
        }

        public void SetTarget(Character character, Character? target)
        {
            character.TargetService.SetTarget(target);
        }

        public bool IsTargeting(Character character, Character? target)
        {
            return character.TargetService.Target == target;
        }
    }
}