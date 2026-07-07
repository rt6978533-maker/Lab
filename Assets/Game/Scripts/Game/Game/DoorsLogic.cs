using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [AddComponentMenu("Game/DoorsLogic")]
    public class DoorsLogic : MonoBehaviour
    {
        public UnityEvent InvokeActive;

        [SerializeField] private int _counterTest = 2;
        [SerializeField] private bool _multiInvoke = false;

        private int _counterActive = 0;

        private bool _stateInvoke = false;

        public void CounterAdd()
        {
            _counterActive++;

            if (_counterTest <= _counterActive)
            {
                if (!_multiInvoke && _stateInvoke) return;

                _stateInvoke = true;
                InvokeActive.Invoke();
            }
        }

        public void CounterRemove() => _counterActive--;
    }
}