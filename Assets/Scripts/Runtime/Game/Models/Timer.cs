#nullable enable

using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Models
{
    public class Timer : ITimer
    {
        private readonly ITimeManager _timeManager;
        
        private float LastReset { get; set; }
        private float TimeSince => _timeManager.Time - LastReset;
        

        public Timer(ITimeManager timeManager)
        {
            _timeManager = timeManager;
        }
        
        public void Reset()
        {
            LastReset = _timeManager.Time;
        }

        public bool Check(float interval)
        {
            return TimeSince > interval;
        }
    }
}