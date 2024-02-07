#nullable enable

using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Abstractions.Helpers
{
    public interface IRaycastHelper
    {
        bool RayCastDown(Vector3 origin, float distance, params LayerName[] layerNames);
    }
}