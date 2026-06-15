using UnityEngine;

namespace Game.Player.ItemsPickUp
{
    public abstract class Items : MonoBehaviour, IItemsPickUp
    {
        [Min(1.0f)]
        public float DistanceInteract = 7;

        [HideInInspector] public bool IsEnable = true;

        public virtual void InteractOne(GameObject plr) { }
        public virtual void InteractTwo(GameObject plr) { }

        public virtual void Disable() { IsEnable = false; }
        public virtual void Enable() { IsEnable = true; }
    }
}