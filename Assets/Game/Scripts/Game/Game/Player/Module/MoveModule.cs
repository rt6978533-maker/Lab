using GaS.Interface;
using GaS.Player;
using UnityEngine;

namespace Game.Player.Module
{
    public class MoveModule : ModuleController<Vector2>, IInitializable<PlayerInputSystem>
    {
        private PlayerInputSystem _input;

        public void Init(PlayerInputSystem arg) => _input = arg;

        protected override Vector2 getValue()
        {
            if (_input == null) return Vector2.zero;
            return _input.Player.Move.ReadValue<Vector2>();
        }
    }
}