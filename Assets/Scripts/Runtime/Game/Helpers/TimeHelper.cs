#nullable enable

using System;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Helpers
{
    public class TimeHelper : ITimeManager
    {
        public float Time => UnityEngine.Time.time;
        public float DeltaTime => UnityEngine.Time.deltaTime;

        private static readonly DateTimeOffset StartUpTime = DateTimeOffset.UtcNow;
        public DateTimeOffset UtcNow => StartUpTime + TimeSpan.FromSeconds(Time);
    }
}