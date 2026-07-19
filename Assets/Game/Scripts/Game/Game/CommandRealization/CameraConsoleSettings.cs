using UnityEngine;
using Game.NewConsole;

namespace Game.CommandRealization
{
    [AddComponentMenu("Game/CommandRealization/CameraConsoleSettings")]
    public class CameraConsoleSettings : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [ConsoleCommand("cam_fov", RequireBinding.Cheats)]
        public void SetCamFov(float fov = 60) { _camera.fieldOfView = fov; }

        [ConsoleCommand("cam_bg", RequireBinding.Cheats)]
        public void SetCamBG(byte r = 0, byte g = 0, byte b = 0) {
            float resultR = r / 255.0f;
            float resultG = g / 255.0f;
            float resultB = b / 255.0f;

            _camera.backgroundColor = new Color(resultR, resultG, resultB);
        }
    }
}