using Game.Player.ItemsPickUp;
using Tools.Default;
using UnityEngine;

namespace Game.Diagnostic
{
    [AddComponentMenu("Game/Player/ItemsPickUp/Items/ItemsDestroy")]
    public class ItemsDestroy : Items, IDestroy
    {
        public void Destroy() => Destroy(gameObject);

        public override void InteractOne(GameObject plr) => Destroy();
        public override void InteractTwo(GameObject plr) => Destroy();
    }
}