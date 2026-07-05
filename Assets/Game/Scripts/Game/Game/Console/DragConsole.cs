using Tools.System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/DragConsole")]
    [RequireComponent(typeof(DragSystem))]
    public class DragConsole : MonoBehaviour, IDrag
    {
        [SerializeField] private RectTransform _rectTransform;

        private void Awake()
        {
            if (_rectTransform == null)
            {
                Debug.LogError("[DragConsole][Awake] _rectTransform is null.");
                enabled = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }
    }
}