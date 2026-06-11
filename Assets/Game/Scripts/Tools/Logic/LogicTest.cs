using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/LogicTest")]
    public class LogicTest : MonoBehaviour
    {
        enum TypeLogicTest
        {
            less_than,  // <
            greater_than, // >
            less_or_equal, // <=
            greater_or_equal, // >=
            equals  // ==
        }

        [SerializeField] private TypeLogicTest _type;

        public UnityEvent OnTrue;
        public float Value;

        public void Test(float value)
        {
            bool isActive = _type switch
            {
                TypeLogicTest.less_than => Value < value,
                TypeLogicTest.greater_than => Value > value,
                TypeLogicTest.less_or_equal => Value <= value,
                TypeLogicTest.greater_or_equal => Value >= value,
                TypeLogicTest.equals => Value == value,
                _ => false
            };

            if (isActive) OnTrue?.Invoke();
        }
        public void Test(long value) => Test((float)value);
        public void Test(int value) => Test((float)value);
        public void Test(short value) => Test((float)value);
        public void Test(byte value) => Test((float)value);
    }
}
