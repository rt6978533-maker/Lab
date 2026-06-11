using UnityEngine;
using UnityEngine.Events;

namespace Tools.Data
{
    [AddComponentMenu("Tools/Data/MemoryFloat")]
    public class MemoryFloat : MonoBehaviour
    {
        public UnityEvent<float> OnChange;

        private float _value;

        public void Set(float value)
        {
            _value = value;
            OnChange?.Invoke(value);
        }
        public float GetValue() => _value;

        public void Add(float value)
        {
            _value += value;
            OnChange?.Invoke(value);
        }
        public void Remove(float value)
        {
            _value -= value;
            OnChange?.Invoke(value);
        }
    }
}