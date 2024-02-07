#nullable enable

using System;

namespace Runtime.Abstractions.Helpers
{
    public interface ICoroutineManager
    {
        void AddTimedCallback(float callbackSeconds, Action callback);
    }
}