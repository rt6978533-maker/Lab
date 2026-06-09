using UnityEngine;

namespace Game.Player.Weapon
{
    public abstract class Weapon : MonoBehaviour, IFireable
    {
        public bool IsEnable { get; protected set; }

        private void SetState(bool value)
        {
            IsEnable = value;
            gameObject.SetActive(value);
        }

        public void Enable() { if (!IsEnable) SetState(true); }
        public void Disable() { if (IsEnable) SetState(false); }

        public abstract void Fire();
    }
}