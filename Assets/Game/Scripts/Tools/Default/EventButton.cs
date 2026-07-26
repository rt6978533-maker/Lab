using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Tools.Default
{
    [AddComponentMenu("Tools/Default/EventButton")]
    public class EventButton : MonoBehaviour
    {
        [Tooltip("Current Action to events")]
        public InputAction Action;

        [Header("Addition Settings")]
        [SerializeField]
        private bool _testInCurrentSelectedGameObject = true;

        public UnityEvent OnPerformed, OnCanceled, OnStarted;

        private void Action_performed(InputAction.CallbackContext obj) {
            if (_testInCurrentSelectedGameObject && EventSystem.current.currentSelectedGameObject != null) return;
            OnPerformed?.Invoke(); 
        }

        private void Action_canceled(InputAction.CallbackContext obj) {
            if (_testInCurrentSelectedGameObject && EventSystem.current.currentSelectedGameObject != null) return;
            OnCanceled?.Invoke();
        }
        private void Action_started(InputAction.CallbackContext obj) {
            if (_testInCurrentSelectedGameObject && EventSystem.current.currentSelectedGameObject != null) return;
            OnStarted?.Invoke();
        }

        private void OnEnable()
        {
            Action.Enable();

            Action.performed += Action_performed;
            Action.canceled += Action_canceled;
            Action.started += Action_started;
        }

        private void OnDisable()
        {
            Action.performed -= Action_performed;
            Action.canceled -= Action_canceled;
            Action.started -= Action_started;
        }
    }
}