using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/T-Trigger")]
    public class T_Trigger : MonoBehaviour
    {
        [SerializeField] private bool _state = false;

        public UnityEvent Q1, Q2;

        public void Invoke()
        {
            _state = !_state;

            if (_state) Q1?.Invoke();
            else Q2?.Invoke();
        }
    }
}
