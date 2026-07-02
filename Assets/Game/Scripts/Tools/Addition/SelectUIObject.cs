using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.Addition
{
    [AddComponentMenu("Tools/Addition/SelectUIObject")]
    public class SelectUIObject : MonoBehaviour
    {
        public void Select(GameObject objUI)
        {
            if (objUI != null)
            EventSystem.current.SetSelectedGameObject(objUI);
        }

        public void SelectNull() => EventSystem.current.SetSelectedGameObject(null);
    }
}
