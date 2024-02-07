#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface ITargetController
    {
        public Character? GetTarget(Character character);
        public void SetTarget(Character character, Character? target);
        bool IsTargeting(Character character, Character? target);
    }
}