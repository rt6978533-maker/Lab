using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Tools.Logic
{
    [AddComponentMenu("Tools/Logic/Delay")]
    public class Delay : MonoBehaviour
    {
        public UnityEvent OnInvoke;
        [SerializeField] private float _delay = 10;

        Coroutine _sleeping;

        public void StartDelay()
        {
            _sleeping = StartCoroutine(Sleeping());
        }

        public void StopDelay()
        {
            if (_sleeping == null) return;

            StopCoroutine(_sleeping);
        }

        IEnumerator Sleeping()
        {
            yield return new WaitForSeconds(_delay);
            OnInvoke?.Invoke();
        }
    }
}