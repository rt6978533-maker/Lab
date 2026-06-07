using UnityEngine;

namespace Game.Player.ItemsPickUp
{
    public abstract class Items : MonoBehaviour, IItemsPickUp
    {
        [Min(1.0f)]
        public float DistanceInteract = 1;

        public virtual void InteractOne() { }
        public virtual void InteractTwo() { }
    }
}