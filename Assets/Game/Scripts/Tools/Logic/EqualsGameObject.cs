using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/EqualsGameObject")]
    public class EqualsGameObject : MonoBehaviour
    {
        public GameObject Value;
        public UnityEvent OnTrue;

        public void EqualsMethod(GameObject obj)
        {
            if (Value == null && obj == null) OnTrue?.Invoke();
            else if (Value == obj) OnTrue?.Invoke();
        }
    }
}