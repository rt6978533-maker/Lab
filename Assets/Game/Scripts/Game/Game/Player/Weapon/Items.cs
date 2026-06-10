using UnityEngine;

namespace Game.Player.Weapon
{
    public abstract class Items : MonoBehaviour
    {
        public bool IsEnable { get; protected set; }

        [SerializeField] private GameObject _dropedItems = null;

        private void SetState(bool value)
        {
            IsEnable = value;
            gameObject.SetActive(value);
        }

        public void Enable() { if (!IsEnable) SetState(true); }
        public void Disable() { if (IsEnable) SetState(false); }

        public void InvokeDrop()
        {
            if (_dropedItems == null || !IsEnable) return;

            GameObject i = Instantiate(_dropedItems, transform.position, Quaternion.identity);

            SetState(false);
            Drop(i);
        }
        protected virtual void Drop(GameObject dropedItems) { }
    }
}