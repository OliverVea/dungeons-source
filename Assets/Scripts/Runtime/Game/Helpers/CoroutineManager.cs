#nullable enable

using System;
using System.Collections;
using Runtime.Abstractions.Helpers;
using UnityEngine;

namespace Runtime.Game.Helpers
{
    public class CoroutineManager : MonoBehaviour, ICoroutineManager
    {
        public void AddTimedCallback(float callbackSeconds, Action callback)
        {
            StartCoroutine(TimedCallback(callbackSeconds, callback));
        }

        private static IEnumerator TimedCallback(float callbackSeconds, Action callback)
        {
            yield return new WaitForSeconds(callbackSeconds);
            callback();
        }
    }
}