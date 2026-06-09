using UnityEngine;
using UnityEngine.Events;

namespace Tools.Data
{
    [AddComponentMenu("Tools/Data/MemoryByte")]
    public class MemoryByte : MonoBehaviour
    {
        private byte _value;
        public UnityEvent<byte> OnChange;

        public void SetValue(byte value)
        {
            _value = value;
            OnChange?.Invoke(value);
        }
        public byte GetValue() => _value;
        public void Add(byte value) { 
            _value += value;
            OnChange?.Invoke(value);
        }
        public void Remove(byte value) {
            _value -= value;
            OnChange?.Invoke(value);
        }
        public void Add(int value) { 
            _value += (byte)value;
            OnChange?.Invoke(_value);
        }
        public void Remove(int value) {
            _value -= (byte)value;
            OnChange?.Invoke(_value);
        }
    }
}