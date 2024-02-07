#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Controller
{
    public interface ICameraController
    {
        void Pan(float change);
        void Zoom(float change);
        Ray GetRay(Vector2 mousePosition);
    }
}