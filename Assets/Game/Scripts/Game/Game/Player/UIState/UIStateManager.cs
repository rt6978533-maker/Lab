using System;
using Tools.Default;
using UnityEngine;

namespace Game.Player.UIState
{
    public interface ISetState { public void SetState(UIStateContext context); }

    [AddComponentMenu("Game/Player/UIState/UIStateManager")]
    public class UIStateManager : MonoBehaviour, ISetState
    {
        public UIStateContext currentState { get; private set; }

        [SerializeField]
        private PlayerController _characterController;

        [SerializeField]
        private CursorManager _cursorManager;

        private void UpdateUI(GameObject uiDisable, GameObject uiEnable) {
            uiDisable?.SetActive(false);
            uiEnable?.SetActive(true);
        }

        private void UpdateLogic(UIBehaviorFlags flags) {
            bool blockeMove = (flags & UIBehaviorFlags.BlockMove) != 0;
            bool blockeLook = (flags & UIBehaviorFlags.BlockLook) != 0;
            bool showCursor = (flags & UIBehaviorFlags.ShowCursor) != 0;
            bool unlockedCursor = (flags & UIBehaviorFlags.UnlockedCursor) != 0;
            bool freezeTime = (flags & UIBehaviorFlags.FreezeTime) != 0;

            _characterController.Enable();
            Time.timeScale = freezeTime ? 0 : 1;
            _cursorManager.SetCursor(unlockedCursor ? CursorLockMode.None : CursorLockMode.Locked, showCursor);

            if (blockeMove) _characterController.DisableMove();
            if (blockeLook) _characterController.DisableLook();
        }

        public void SetState(UIStateContext context)
        {
            UpdateUI(currentState.UIContent, context.UIContent);
            currentState = context;
            UpdateLogic(context.BehaviorFlags);
        }
    }
}