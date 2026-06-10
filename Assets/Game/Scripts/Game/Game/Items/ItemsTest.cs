using Game.Player;
using Game.Player.ItemsPickUp;
using UnityEngine;

namespace Game.Diagnostic
{
    [AddComponentMenu("Game/Player/ItemsPickUp/Items/ItemsTest")]
    public class ItemsTest : Items
    {
        public override void InteractOne(GameObject plr) =>
            Debug.Log("TEST1");

        public override void InteractTwo(GameObject plr) =>
            Debug.Log("TEST2");
    }
}