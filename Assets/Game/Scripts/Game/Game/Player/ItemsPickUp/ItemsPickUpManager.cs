using GaS.Interface;
using GaS.Player;
using Tools.System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player.ItemsPickUp
{
    interface IItemsPickUp {
        void InteractOne();
        void InteractTwo();
    }

    [RequireComponent(typeof(RaycastSystem))]
    [AddComponentMenu("Game/Player/ItemsPickUp/Manager")]
    public class ItemsPickUpManager : MonoBehaviour, 
        IInitializable<PlayerInputSystem>, IEnterRaycast, IExitRaycast
    {
        [SerializeField] private GameObject _gameObjectPressE;

        private Items _currentBufferObject;
        private PlayerInputSystem _input;

        public void Init(PlayerInputSystem arg)
        {
            _input = arg;
        }

        private void OnEnable()
        {
            if (_input == null) return;

            _input.Player.Interact.performed += InteractOne;
            _input.Player.InteractTwo.performed += InteractTwo;
        }
        private void OnDisable()
        {
            if (_input == null) return;

            _input.Player.Interact.performed -= InteractOne;
            _input.Player.InteractTwo.performed -= InteractTwo;
        }

        private bool IsRange(Vector3 pos1, Vector3 pos2, float distance) =>
            (pos1-pos2).sqrMagnitude <= distance;

        private bool TestRange()
        {
            if (_currentBufferObject != null && IsRange(
                _currentBufferObject.transform.position, 
                transform.position,
                _currentBufferObject.DistanceInteract))
                return true;
            return false;
        }

        //Input (core logic)
        private void InteractOne(InputAction.CallbackContext c)
        {
            if (_currentBufferObject == null || !TestRange()) return;

            _currentBufferObject.InteractOne();
        }
        private void InteractTwo(InputAction.CallbackContext c)
        {
            if (_currentBufferObject == null || !TestRange()) return;

            _currentBufferObject.InteractTwo();
        }

        private void Update()
        {
            if (_gameObjectPressE == null) return;

            if (!_gameObjectPressE.activeSelf && TestRange()) {
                _gameObjectPressE?.SetActive(true);
            }
            else if (_gameObjectPressE.activeSelf && !TestRange()) {
                _gameObjectPressE.SetActive(false);
            }
        }

        //Raycast
        public void EnterRaycast(GameObject obj) {
            if (obj.TryGetComponent(out Items i)) {
                _currentBufferObject = i;
                
            }
        }
        public void ExitRaycast(GameObject obj) {
            _currentBufferObject = null;
            _gameObjectPressE?.SetActive(false);
        }
    }
}