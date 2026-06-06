using Game.Player;
using UnityEngine;

namespace Game.Diagnostic
{
    [AddComponentMenu("Game/Diagnostic/ItemsTest")]
    public class ItemsTest : MonoBehaviour, IItemsPickUp
    {
        public void InteractOne()
        {
            Debug.Log("TEST1");
        }

        public void InteractTwo()
        {
            Debug.Log("TEST2");
        }
    }
}