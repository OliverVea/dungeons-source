#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface IConcentrationController
    {
        public void StartConcentration(Character character, IConcentration concentration);
        public bool Interrupt(Character character, InterruptionSource interruptionSource);
        public bool Interrupt(Character character, InterruptionSource interruptionSource, Character source);
        bool IsConcentrating(Character character);
    }
}