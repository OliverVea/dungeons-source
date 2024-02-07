#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IAnimationController
    {
        void Trigger(Character character, AnimationName animationName);
    }
}