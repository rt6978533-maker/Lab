using UnityEngine;
using UnityEngine.Events;

namespace Tools.Data
{
    [AddComponentMenu("Tools/Data/MemoryBool")]
    public class MemoryBool : MonoBehaviour
    {
        private bool _value;

        public UnityEvent<bool> OnChange;

        public void SetValue(bool value)
        {
            _value = value;
            OnChange?.Invoke(value);
        }

        public bool GetValue() => _value;
    }
}