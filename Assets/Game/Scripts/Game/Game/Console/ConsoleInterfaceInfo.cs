using UnityEngine;

namespace Game.NewConsole
{
    [AddComponentMenu("Game/NewConsole/ConsoleInterfaceInfo")]
    public class ConsoleInterfaceInfo : MonoBehaviour
    {
        [SerializeField] private ConsoleBakedInfo _consoleBakedInfo;
        [SerializeField] private ConsoleBaked _consoleBaked;

        private void Awake()
        {
            if (_consoleBakedInfo == null)
            {
                Debug.LogError("[ConsoleInterfaceInfo] _consoleBakedInfo is null.");
                enabled = false;
                return;
            }
            if (_consoleBaked == null)
            {
                Debug.LogError("[ConsoleInterfaceInfo] _consoleBaked is null.");
                enabled = false;
                return;
            }
        }
    }
}