using UnityEngine;
using UnityEngine.Events;

namespace Tools.Addition
{
    [AddComponentMenu("Tools/Addition/EqualsStateGameObject")]
    public class EqualsStateGameObject : MonoBehaviour
    {
        [SerializeField] private bool _equalsState;

        public UnityEvent OnTrue;

        public void Equals(GameObject target)
        {
            if (target.activeSelf == _equalsState)
            {
                OnTrue?.Invoke();
            }
        }
    }
}
