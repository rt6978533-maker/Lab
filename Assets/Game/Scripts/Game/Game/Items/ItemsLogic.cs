using UnityEngine;
using UnityEngine.Events;

namespace Game.Player.ItemsPickUp
{
    [AddComponentMenu("Game/Player/ItemsPickUp/Items/ItemsLogic")]
    public class ItemsLogic : Items
    {
        public UnityEvent OnInteractOne, OnInteractTwo;

        public override void InteractOne() { 
            OnInteractOne?.Invoke();
        }
        public override void InteractTwo() { 
            OnInteractTwo?.Invoke();
        }
    }
}