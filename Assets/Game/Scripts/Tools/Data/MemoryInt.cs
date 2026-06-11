using UnityEngine;
using UnityEngine.Events;

namespace Tools.Data
{
    [AddComponentMenu("Tools/Data/MemoryInt")]
    public class MemoryInt : MonoBehaviour
    {
        public UnityEvent<int> OnChange;

        private int _value;

        public void Set(int value)
        {
            _value = value;
            OnChange?.Invoke(_value);
        }
        public int GetValue() => _value;

        public void Add(int value)
        {
            _value += value;
            OnChange?.Invoke(_value);
        }
        public void Remove(int value)
        {
            _value -= value;
            OnChange?.Invoke(value);
        }
    }
}
