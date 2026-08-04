using UnityEngine;

namespace Game.Player
{
    public partial class PlayerController
    {
        public void EnableMove() => _move.Enable();
        public void DisableMove() => _move.Enable();
        public void EnableLook() => _look.Enable();
        public void DisableLook() => _look.Enable();

        public void Enable()
        {
            EnableMove();
            EnableLook();
            _sprint?.Enable();
        }
        public void Disable()
        {
            DisableMove();
            DisableLook();
            _sprint?.Disable();
        }
    }
}