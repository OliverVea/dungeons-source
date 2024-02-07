#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface IConcentrationService
    {
        IConcentration? Concentration { get; set; }
        void AddModifier(ConcentrationModifier modifier);
        void RemoveModifier(ConcentrationModifier modifier);
        IEnumerable<ConcentrationModifier> ListModifiers();
    }
}