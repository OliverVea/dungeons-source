#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Controllers
{
    public class ConcentrationController : IConcentrationController
    {
        public void StartConcentration(Character character, IConcentration concentration)
        {
            if (character.ConcentrationService.Concentration is not null) return;

            character.ConcentrationService.Concentration = concentration;
            concentration.Start();
        }

        public bool Interrupt(Character character, InterruptionSource interruptionSource)
        {
            if (character.ConcentrationService.Concentration is null) return false;

            var cancelled = character.ConcentrationService.Concentration.Cancel(interruptionSource);
            if (cancelled) character.ConcentrationService.Concentration = null;

            return cancelled;
        }

        public bool Interrupt(Character character, InterruptionSource interruptionSource, Character source)
        {
            if (character.ConcentrationService.Concentration is null) return false;

            var cancelled = character.ConcentrationService.Concentration.Cancel(interruptionSource, source);
            if (cancelled) character.ConcentrationService.Concentration = null;

            return cancelled;
        }

        public bool IsConcentrating(Character character)
        {
            return character.ConcentrationService.Concentration is not null;
        }
    }
}