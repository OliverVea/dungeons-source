#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Controllers
{
    public class AnimationController : IAnimationController
    {
        public void Trigger(Character character, AnimationName animationName)
        {
            character.AnimationService.Trigger(animationName);
        }
    }
}