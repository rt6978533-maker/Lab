using Game.Player.UIState;
using UnityEngine;

namespace Game.Player.UIState
{
    public class Pause : MonoBehaviour
    {
        [SerializeField]
        private UIStateManager _uiStateManager;

        public void EnablePause(GameObject ui)
        {
            _uiStateManager.SetState(new(10, ui,
                UIBehaviorFlags.BlockMove | UIBehaviorFlags.ShowCursor |
                UIBehaviorFlags.BlockLook | UIBehaviorFlags.FreezeTime |
                UIBehaviorFlags.UnlockedCursor));
        }
        public void DisablePause()
        {
            _uiStateManager.SetState(new(0, null));
        }
    }
}