using Game.Player.UIState;
using UnityEngine;

namespace Game.Player.ItemsPickUp
{
    public class NumberPanel : Items
    {
        [SerializeField]
        private GameObject _panel;

        public override void InteractOne(GameObject plr)
        {
            if (plr.TryGetComponent(out UIStateManager stateManager))
            {
                UIBehaviorFlags flags = UIBehaviorFlags.BlockMove | UIBehaviorFlags.BlockLook |
                    UIBehaviorFlags.ShowCursor | UIBehaviorFlags.UnlockedCursor;

                stateManager.SetState(new(5, _panel, flags));
            }
        }
    }
}