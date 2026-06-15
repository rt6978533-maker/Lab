using UnityEngine;
using UnityEngine.Events;

namespace Tools.Default
{
    public class StartEvent : MonoBehaviour
    {
        public UnityEvent OnStart;

        private void Start() => OnStart?.Invoke();
    }
}