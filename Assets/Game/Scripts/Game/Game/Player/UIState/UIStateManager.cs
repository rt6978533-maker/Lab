using System;
using UnityEngine;

namespace Game.Player.UIState
{
    public interface ISetState { public void SetState(UIStateContext context); }

    [AddComponentMenu("Game/Player/UIState/UIStateManager")]
    public class UIStateManager : MonoBehaviour, ISetState
    {
        public UIStateContext currentState { get; private set; }

        private void UpdateUI() {
            currentState.UIContent.SetActive(true);
            
        }

        private void UpdateLogic() {

        }

        public void SetState(UIStateContext context)
        {
            if (!context.IsValid)
            { Debug.LogError("[UIStateManager][SetState] context has not validate."); return; }

            if (currentState.IsValid) currentState.UIContent.SetActive(false);

            currentState = context;
            UpdateLogic();
            UpdateUI();
        }
    }
}