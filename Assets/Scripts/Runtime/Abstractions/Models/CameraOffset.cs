#nullable enable

namespace Runtime.Abstractions.Models
{
    public record CameraOffset
    {
        public float Distance { get; set; }
        public float LeftRightAngle { get; set; }
    }
}