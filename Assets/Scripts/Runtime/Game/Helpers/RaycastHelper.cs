#nullable enable

using System.Linq;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Helpers
{
    public class RaycastHelper : IRaycastHelper
    {
        private readonly ILayerHelper _layerHelper;

        public RaycastHelper(ILayerHelper layerHelper)
        {
            _layerHelper = layerHelper;
        }

        public bool RayCastDown(Vector3 origin, float distance, params LayerName[] layerNames)
        {
            if (!layerNames.Any()) return Physics.Raycast(origin, Vector3.down, distance);
            
            var layerMask =  _layerHelper.All(layerNames);
            return Physics.Raycast(origin, Vector3.down, distance, layerMask);
        }
    }
}