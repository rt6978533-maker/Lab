using System;
using UnityEngine;

namespace Game.Player.UIState
{
    [Flags]
    public enum UIBehaviorFlags
    {
        None = 0,

        BlockMove = 1 << 0,
        BlockLook = 1 << 1,
        ShowCursor = 1 << 2,
    }

    public readonly struct UIStateContext
    {
        public readonly uint ID;
        public readonly GameObject UIContent;
        public readonly UIBehaviorFlags BehaviorFlags;

        public bool IsValid => UIContent != null;

        public UIStateContext(uint id, GameObject content, UIBehaviorFlags flags=UIBehaviorFlags.None)
        {
            ID = id;
            UIContent = content;
            BehaviorFlags = flags; 
        }
    }
}