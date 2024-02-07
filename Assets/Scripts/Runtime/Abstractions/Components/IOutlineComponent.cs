#nullable enable

using UnityEngine;

namespace Runtime.Abstractions
{
    public interface IOutlineComponent
    {
        void SetColor(Color borderColor, Color fillColor);
        void SetHover(bool state);
        void SetSelected(bool state);
    }
}