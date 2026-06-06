using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Tools.System
{
    interface IEnterRaycast { void EnterRaycast(GameObject obj); }
    interface IExitRaycast { void ExitRaycast(GameObject obj); }

    [AddComponentMenu("Tools/System/RaycastSystem")]
    public class RaycastSystem : MonoBehaviour
    {    
        [SerializeField] private Transform _transform;
        [SerializeField, Min(0.0f)] private float _distance = 10.5f;

        private GameObject _bufferObject;
        private IEnterRaycast[] _enterInterface;
        private IExitRaycast[] _exitInterface;

        private void Awake()
        {
            _enterInterface = GetComponents<IEnterRaycast>();
            _exitInterface = GetComponents<IExitRaycast>();
        }

        private void EnterRaycast(GameObject obj) {
            foreach (IEnterRaycast enter in _enterInterface) enter?.EnterRaycast(obj);
        }
        private void ExitRaycast(GameObject obj) {
            foreach (IExitRaycast enter in _exitInterface) enter?.ExitRaycast(obj);
        }

        private void Update()
        {
            Ray ray = new Ray(_transform.position, _transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, _distance))
            {
                GameObject obj = hit.transform.gameObject;

                if (_bufferObject != obj)
                {
                    ExitRaycast(_bufferObject);
                    _bufferObject = obj;
                    EnterRaycast(_bufferObject);
                }
            } else if (_bufferObject != null) {
                ExitRaycast(_bufferObject);
                _bufferObject = null;
            }
        }
    }
}