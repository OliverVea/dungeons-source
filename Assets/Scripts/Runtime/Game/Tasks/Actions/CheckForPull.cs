#nullable enable

using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime.Tasks;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;
using Runtime.Game.Extensions;
using Zenject;

namespace Runtime.Game.Tasks.Actions
{
    [TaskCategory("Custom")]
    [TaskName("Check for Pull")]
    public class CheckForPull : Action
    {
        [Inject] private readonly Character _character = null!;
        [Inject] private readonly ICharacterListManager _characterListManager = null!;
        [Inject] private readonly IRangeHelper _rangeHelper = null!;
        [Inject] private readonly IFactionHelper _factionHelper = null!;
        [Inject] private readonly IThreatController _threatController = null!;

        public override TaskStatus OnUpdate()
        {
            var enemiesInRange = GetCharactersInPullRange()
                .Concat(GetCharactersFightingFriendsInRange())
                .Distinct()
                .ToArray();
                
            enemiesInRange.AddThreatTo(_character, Constants.Threat.Pull, _threatController);

            return enemiesInRange.Any() ? TaskStatus.Success : TaskStatus.Failure;
        }

        private IEnumerable<Character> GetCharactersInPullRange()
        {
            return _characterListManager.ListCharacters()
                .ThatAreInRangeOf(_character, Constants.AI.AggroRange, _rangeHelper)
                .OfEnemyFaction(_character, _factionHelper);
        }

        private IEnumerable<Character> GetCharactersFightingFriendsInRange()
        {
            return _characterListManager.ListCharacters()
                .ThatAreInRangeOf(_character, Constants.AI.AggroRange, _rangeHelper)
                .OfSameFaction(_character, _factionHelper)
                .SelectMany(_threatController.ListTargets);
        }
    }
}