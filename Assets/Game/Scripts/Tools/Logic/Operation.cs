using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/Operation")]
    public class Operation : MonoBehaviour
    {
        private enum Operator
        {
            Plus, Minus, Multiplication, Division, Equals, Exponent
        }

        public float Value1, Value2;
        
        public UnityEvent<float> OnResult;

        [SerializeField] private Operator _typeOperation;

        private float Value3;

        public void SetValue1(float value) => Value1 = value;
        public void SetValue2(float value) => Value2 = value;

        private void Invoke() => OnResult?.Invoke(Value3);

        public void Calculate()
        {
            switch (_typeOperation)
            {
                case Operator.Equals:
                    Value3 = Value2;
                    Invoke();
                    return;
                case Operator.Minus:
                    Value3 = Value1 - Value2;
                    Invoke();
                    return;
                case Operator.Plus:
                    Value3 = Value1 + Value2;
                    Invoke();
                    return;
                case Operator.Multiplication:
                    Value3 = Value1 * Value2;
                    Invoke();
                    return;
                case Operator.Division:
                    Value3 = Value1 / Value2;
                    Invoke();
                    return;
                case Operator.Exponent:
                    Value3 = Mathf.Pow(Value1, Value2);
                    Invoke();
                    return;
            }
        }
    }
}