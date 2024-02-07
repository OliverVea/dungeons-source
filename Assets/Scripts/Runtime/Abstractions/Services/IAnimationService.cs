#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IAnimationService
    {
        void SetSpeed(float speed);
        void Trigger(AnimationName animationName);
    }
}