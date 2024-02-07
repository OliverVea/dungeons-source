#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Helpers
{
    public class LineOfSightHelper : ILineOfSightHelper
    {
        private readonly int _layerMask;

        public LineOfSightHelper(ILayerHelper layerHelper)
        {
            _layerMask = layerHelper.Except(LayerName.Characters, LayerName.Cursor);
        }

        public bool HasLineOfSight(Character source, Character target) => HasLineOfSight(source.Head, target.Head);

        private bool HasLineOfSight(Vector3 source, Vector3 target)
        {
            var delta = target - source;
            
            var ray = new Ray(source, delta.normalized);
            var distance = delta.magnitude;
            
            var hit = Physics.Raycast(ray, out var hitInfo, distance, _layerMask);

            return !hit;
        }
    }
}