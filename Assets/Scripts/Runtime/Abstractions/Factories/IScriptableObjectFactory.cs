#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Factories
{
    public interface IScriptableObjectFactory
    {
        T CreateObject<T>(T prefabObject) where T : ScriptableObject;
    }
}