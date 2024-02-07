#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Helpers
{
    public interface ILayerHelper
    {
        int All(params LayerName[] layers);
        int Except(params LayerName[] layers);
    }
}