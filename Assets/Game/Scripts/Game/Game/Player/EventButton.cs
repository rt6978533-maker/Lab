using GaS.Interface;
using GaS.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class EventButton : MonoBehaviour, IInitializable<PlayerInputSystem>
    {
        public InputAction Test;

        public void Init(PlayerInputSystem arg)
        {
            throw new System.NotImplementedException();
        }
    }
}