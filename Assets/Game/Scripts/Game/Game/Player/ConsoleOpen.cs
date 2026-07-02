using GaS.Interface;
using GaS.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/ConsoleInputEvents")]
    public class ConsoleInputEvents : MonoBehaviour, IInitializable<PlayerInputSystem>
    {
        public UnityEvent OnConsoleButton;

        private InputAction _buttonConsole;
        private bool _state = false;

        public void Init(PlayerInputSystem arg)
        {
            _buttonConsole = arg.Player.Console;
            OnEnable();
        }

        private void PressedButton(InputAction.CallbackContext c) => OnConsoleButton?.Invoke();

        public void OnEnable()
        {
            if (_state || _buttonConsole == null) return;

            _buttonConsole.performed += PressedButton;
            _state = true;
        }

        public void OnDisable()
        {
            if (_state == false || _buttonConsole == null) return;

            _buttonConsole.performed -= PressedButton;
            _state = false;
        }
    }
}
