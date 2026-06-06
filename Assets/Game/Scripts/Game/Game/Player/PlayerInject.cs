using GaS.Interface;
using GaS.Player;
using UnityEngine;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerInject")]
    public class PlayerInject : MonoBehaviour
    {
        private PlayerInputSystem _input;

        public void InjectInput(PlayerInputSystem input)
        {
            foreach (
                IInitializable<PlayerInputSystem> i in
                GetComponents<IInitializable<PlayerInputSystem>>()) i.Init(input);
        }

        private void Awake()
        {
            _input = new();

            InjectInput(_input);
        }

        private void OnDisable() => _input.Player.Disable();
        private void OnEnable() => _input.Player.Enable();
        private void OnDestroy() => _input.Dispose();
    }
}