using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/Equals")]
    public class Equals : MonoBehaviour
    {
        public float Value;
        public UnityEvent OnTrue;

        public void EqualsMethod(float value)
        {
            if (Value == value) OnTrue?.Invoke();
        }
        public void EqualsMethod(int value)
        {
            if (Value == value) OnTrue?.Invoke();
        }
        public void EqualsMethod(short value)
        {
            if (Value == value) OnTrue?.Invoke();
        }
        public void EqualsMethod(long value)
        {
            if (Value == value) OnTrue?.Invoke();
        }
        public void EqualsMethod(double value)
        {
            if (Value == value) OnTrue?.Invoke();
        }
    }
}