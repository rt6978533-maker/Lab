using UnityEngine;
using UnityEngine.Events;

namespace Game.Player.ItemsPickUp
{
    [AddComponentMenu("Game/Player/ItemsPickUp/Items/ItemsLogic")]
    public class ItemsLogic : Items
    {
        public UnityEvent<GameObject> OnInteractOne, OnInteractTwo;

        public override void InteractOne(GameObject plr) { 
            OnInteractOne?.Invoke(plr);
        }
        public override void InteractTwo(GameObject plr) { 
            OnInteractTwo?.Invoke(plr);
        }
    }
}