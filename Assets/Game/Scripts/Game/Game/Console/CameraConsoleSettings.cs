using Unity.VisualScripting;
using UnityEngine;

namespace Game.Console.Command
{
    [AddComponentMenu("Game/Console/Command/CameraConsoleSettings")]
    public class CameraConsoleSettings : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [ConsoleCommand("cam_fov")]
        public void SetCamFov(float fov) { _camera.fieldOfView = fov; }

        [ConsoleCommand("cam_bg")]
        public void SetCamBG(byte r, byte g, byte b = 50) {
            float resultR = r / 255.0f;
            float resultG = g / 255.0f;
            float resultB = b / 255.0f;

            _camera.backgroundColor = new Color(resultR, resultG, resultB);
        }
    }
}