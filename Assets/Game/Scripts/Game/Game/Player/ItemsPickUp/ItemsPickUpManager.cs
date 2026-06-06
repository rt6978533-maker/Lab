using GaS.Interface;
using GaS.Player;
using Tools.System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    interface IItemsPickUp {
        void InteractOne();
        void InteractTwo();
    }

    [RequireComponent(typeof(RaycastSystem))]
    [AddComponentMenu("Game/Player/ItemsPickUpManager")]
    public class ItemsPickUpManager : MonoBehaviour, 
        IInitializable<PlayerInputSystem>, IEnterRaycast, IExitRaycast
    {
        private IItemsPickUp _currentBufferObject;
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

        //Input (core logic)
        private void InteractOne(InputAction.CallbackContext c)
        {
            if (_currentBufferObject == null) return;

            _currentBufferObject.InteractOne();
        }
        private void InteractTwo(InputAction.CallbackContext c)
        {
            if (_currentBufferObject == null) return;

            _currentBufferObject.InteractTwo();
        }

        //Raycast
        public void EnterRaycast(GameObject obj) {
            if (obj.TryGetComponent(out IItemsPickUp i)) _currentBufferObject = i;
        }
        public void ExitRaycast(GameObject obj) => _currentBufferObject = null;
    }
}