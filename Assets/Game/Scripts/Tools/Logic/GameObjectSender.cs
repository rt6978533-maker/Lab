using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/GameObjectSender")]
    public class GameObjectSender : MonoBehaviour
    {
        public GameObject SendObject;
        public UnityEvent<GameObject> OnSender;

        public void Send() => OnSender?.Invoke(SendObject);
    }
}