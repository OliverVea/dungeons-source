#nullable enable
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Abstractions.Helpers
{
    public interface ICameraOffsetHelper
    {
        Vector3 GetPositionOffset(CameraOffset cameraOffset);
    }
}