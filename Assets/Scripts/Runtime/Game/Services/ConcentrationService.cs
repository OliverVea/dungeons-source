#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Services
{
    public class ConcentrationService : IConcentrationService, ITickable
    {
        private readonly Character _character;
        private readonly IMovementController _movementController;
        private readonly IConcentrationController _concentrationController;
        
        private readonly HashSet<ConcentrationModifier> _concentrationModifiers = new();

        public ConcentrationService(IConcentrationController concentrationController, IMovementController movementController, Character character)
        {
            _concentrationController = concentrationController;
            _movementController = movementController;
            _character = character;
        }

        public IConcentration? Concentration { get; set; }

        public void AddModifier(ConcentrationModifier modifier)
        {
            _concentrationModifiers.Add(modifier);
        }

        public void RemoveModifier(ConcentrationModifier modifier)
        {
            _concentrationModifiers.Remove(modifier);
        }
 
        public IEnumerable<ConcentrationModifier> ListModifiers()
        {
            return _concentrationModifiers;
        }

        public void Tick()
        {
            if (Concentration is null) return;

            var isMoving = _movementController.IsMoving(_character);
            if (isMoving)
            {
                var cancelled = _concentrationController.Interrupt(_character, InterruptionSource.Movement);
                if (cancelled) return;
            }

            var concentrationFinished = Concentration.TimeSinceStarted >= Concentration.TotalTime;
            if (!concentrationFinished) return;
            
            Concentration.Finish();
            Concentration = null;
        }
    }
}