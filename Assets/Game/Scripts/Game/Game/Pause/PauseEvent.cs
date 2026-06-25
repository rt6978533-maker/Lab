using GaS.Interface;
using GaS.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerInject))]
    [AddComponentMenu("Game/Player/PauseEvent")]
    public class PauseEvent : MonoBehaviour, IInitializable<PlayerInputSystem>
    {
        public UnityEvent OnPause;
        InputAction _input;

        private bool _state;

        public void Init(PlayerInputSystem arg)
        {
            _input = arg.Player.Pause;
            OnEnable();
        }

        private void OnEnable()
        {
            if (_input == null && _state) return;

            _input.performed += PauseClicked;
            _state = true;
        }
        private void OnDisable()
        {
            if (_input == null && !_state) return;

            _input.performed -= PauseClicked;
            _state = false;
        }

        private void PauseClicked(InputAction.CallbackContext c)
        {
            OnPause?.Invoke();
        }
    }
}
