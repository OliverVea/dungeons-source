#nullable enable

using BehaviorDesigner.Runtime.Tasks;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Zenject;

namespace Runtime.Game.Tasks.Conditionals
{
    [TaskCategory("Custom")] 
    [TaskDescription("Returns success if the character is in combat.")]
    public class IsInCombat : BaseConditional
    {
        [Inject] private readonly Character _character = null!;
        [Inject] private readonly IThreatController _combatController = null!;
        
        public override string FriendlyName => "Is" + (inverted ? " not" : "") + " in Combat";

        protected override bool Check()
        {
            return _combatController.IsInCombat(_character);
        }
    }
}