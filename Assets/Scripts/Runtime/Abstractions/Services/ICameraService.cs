#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public interface ICameraService
    {
        UnityEngine.Camera Camera { get; }
        CameraOffset CameraOffset { get; }
    }
}