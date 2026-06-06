using GaS.Interface;
using GaS.Player;
using UnityEngine;

namespace Game.Player.Module
{
    public class SprintModule : ModuleController<bool>, IInitializable<PlayerInputSystem>
    {
        private PlayerInputSystem _input;

        public void Init(PlayerInputSystem arg) => _input = arg;

        protected override bool getValue()
        {
            if (_input == null) return false;

            return _input.Player.Sprint.IsPressed();
        }
    }
}