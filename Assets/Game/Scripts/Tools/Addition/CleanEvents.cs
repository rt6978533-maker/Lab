using UnityEngine;
using UnityEngine.Events;

namespace Tools.Addition
{
    [AddComponentMenu("Tools/Addition/CleanEvents")]
    public class CleanEvents : MonoBehaviour
    {
        public UnityEvent OnInvoke;

        public void Trigger(object obj) => OnInvoke?.Invoke();
        public void Trigger(object[] obj) => OnInvoke?.Invoke();
    }
}