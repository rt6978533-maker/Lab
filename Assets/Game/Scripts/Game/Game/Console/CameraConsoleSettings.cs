using UnityEngine;

namespace Game.Console.Command
{
    [AddComponentMenu("Game/Console/Command/CameraConsoleSettings")]
    public class CameraConsoleSettings : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [ConsoleCommand("cam_fov")]
        public void SetCamFov(string value)
        {
            float fov = 90;

            if (float.TryParse(value, out fov)) { _camera.fieldOfView = fov; }
            else {
                Debug.LogError("[CameraConsoleSettings][SetCamFov] arg command is not float parse"); 
                return;
            }
        }

        [ConsoleCommand("cam_bg")]
        public void SetCamBG(string r, string g, string b)
        {
            int R = 0, G = 0, B = 0;

            if (int.TryParse(r, out int _r)) R = _r;
            else { Debug.LogError("[CameraConsoleSettings][SetCamBG] 1 args command is not int parse"); return; }
            if (int.TryParse(g, out int _g)) G = _g;
            else { Debug.LogError("[CameraConsoleSettings][SetCamBG] 2 args command is not int parse"); return; }
            if (int.TryParse(b, out int _b)) B = _b;
            else { Debug.LogError("[CameraConsoleSettings][SetCamBG] 3 args command is not int parse"); return; }

            float resultR = R / 255.0f;
            float resultG = G / 255.0f;
            float resultB = B / 255.0f;

            _camera.backgroundColor = new Color(resultR, resultG, resultB);
        }
    }
}