#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Services
{
    public class ManaService : BaseStatService, IManaService
    {
        private readonly Character _character;
        private readonly IStatsController _statsController;
    
        public ManaService(
            ITimeManager timeManager,
            Character character,
            IStatsController statsController) : base(timeManager)
        {
            _character = character;
            _statsController = statsController;
        }

        protected override float Max => _statsController.GetMana(_character);
        protected override float RegenerationPerSecond => _statsController.GetManaPerSecond(_character);
        protected override float InitialValue => Max;
    }
}