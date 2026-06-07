using Game.Player;
using Game.Player.ItemsPickUp;
using UnityEngine;

namespace Game.Diagnostic
{
    [AddComponentMenu("Game/Player/ItemsPickUp/Items/ItemsTest")]
    public class ItemsTest : Items
    {
        public override void InteractOne() =>
            Debug.Log("TEST1");

        public override void InteractTwo() =>
            Debug.Log("TEST2");
    }
}