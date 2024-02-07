# nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Services
{
    public class HealthService : BaseStatService, IHealthService
    {
        private readonly Character _character;
        private readonly IStatsController _statsController;
        
        public HealthService(
            ITimeManager timeManager,
            Character character,
            IStatsController statsController) : base(timeManager)
        {
            _character = character;
            _statsController = statsController;
        }

        protected override float Max => _statsController.GetHealth(_character);
        protected override float RegenerationPerSecond => _statsController.GetHealthPerSecond(_character);
        protected override float InitialValue => Max;
    }
}