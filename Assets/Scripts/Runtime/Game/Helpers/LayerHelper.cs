# nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Helpers
{
    public class LayerHelper : ILayerHelper
    {
        private static readonly Dictionary<LayerName, int> LayerNameLookup = new()
        {
            { LayerName.Default, 1 << 0 },
            { LayerName.TransparentFx, 1 << 1 },
            { LayerName.IgnoreRaycast, 1 << 2 },
            { LayerName.Water, 1 << 4 },
            { LayerName.Ui, 1 << 5 },
            { LayerName.Ground, 1 << 8 },
            { LayerName.Characters, 1 << 9 },
            { LayerName.Cursor, 1 << 15 },
        };

        public int All(params LayerName[] layers)
        {
            return layers.Select(layer => LayerNameLookup[layer]).Sum();
        }

        public int Except(params LayerName[] layers)
        {
            return ~All(layers);
        }
    }
}