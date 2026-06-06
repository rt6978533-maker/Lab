using UnityEngine;

namespace Tools.Default
{
    [AddComponentMenu("Tools/Default/CursorManager")]
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private CursorLockMode _mode;
        [SerializeField] private bool _isVisible = true;

        /// <summary>
        /// Set cursor in args settings.
        /// </summary>
        public void SetCursor(CursorLockMode mode, bool visible)
        {
            Cursor.lockState = mode;
            Cursor.visible = visible;
        }
        /// <summary>
        /// Set cursor in settings data.
        /// </summary>
        [ContextMenu("SetCursor")]
        public void SetCursor() => SetCursor(_mode, _isVisible);

        private void Start() => SetCursor();
    }
}