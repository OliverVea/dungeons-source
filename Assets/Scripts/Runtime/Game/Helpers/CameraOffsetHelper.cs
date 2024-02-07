#nullable enable
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Helpers
{
    public class CameraOffsetHelper : ICameraOffsetHelper
    {
        public Vector3 GetPositionOffset(CameraOffset cameraOffset)
        {
            var offset = Vector3.back * cameraOffset.Distance;
            var upDownAngle = GetUpDownAngle(cameraOffset);

            var rotation = Quaternion.Euler(upDownAngle, cameraOffset.LeftRightAngle, 0);
            
            return rotation * offset;
        }

        private static float GetUpDownAngle(CameraOffset cameraOffset)
        {
            return Mathf.Lerp(0, 50, cameraOffset.Distance / 6f);
        }
    }
}