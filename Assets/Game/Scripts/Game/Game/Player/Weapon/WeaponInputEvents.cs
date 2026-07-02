using GaS.Interface;
using GaS.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game.Player.Weapon
{
    [AddComponentMenu("Game/Player/Weapon/WeaponInputEvents")]
    [RequireComponent(typeof(PlayerInject))]
    public class WeaponInputEvents : MonoBehaviour, IInitializable<PlayerInputSystem>
    {
        public UnityEvent OnFire, OnDrop;

        private PlayerInputSystem _input;
        private bool _state = false;

        public void Init(PlayerInputSystem arg)
        {
            _input = arg;
            OnEnable();
        }

        public void OnEnable()
        {
            if (_input == null || _state) return;

            _state = true;
            _input.Player.Attack.performed += Fire;
            _input.Player.Drop.performed += Drop;
        }
        public void OnDisable()
        {
            if (_input == null || !_state) return;

            _state = false;
            _input.Player.Attack.performed -= Fire;
            _input.Player.Drop.performed -= Drop;
        }
        private void Fire(InputAction.CallbackContext c) => OnFire?.Invoke();
        private void Drop(InputAction.CallbackContext c) => OnDrop?.Invoke();
    }
}