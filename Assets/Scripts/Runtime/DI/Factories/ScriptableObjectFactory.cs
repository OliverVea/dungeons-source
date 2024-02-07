#nullable enable

using System;
using Runtime.Abstractions.Factories;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Runtime.DI.Factories
{
    public class ScriptableObjectFactory : IScriptableObjectFactory
    {
        private readonly DiContainer _diContainer;

        public ScriptableObjectFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T CreateObject<T>(T prefabObject) where T : ScriptableObject
        {
            var scriptableObject = Object.Instantiate(prefabObject);
            if (scriptableObject is null)
            {
                throw new ArgumentException($"Could not clone provided object {prefabObject}", nameof(prefabObject));
            }
            
            _diContainer.Inject(scriptableObject);

            return scriptableObject;
        }
    }
}