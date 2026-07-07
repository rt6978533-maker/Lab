using Tools.System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/DragConsole")]
    [RequireComponent(typeof(DragSystem))]
    public class DragSizeConsole : MonoBehaviour, IDrag
    {
        [SerializeField] private RectTransform _rectTransform;

        private void Awake()
        {
            if (_rectTransform == null)
            {
                Debug.LogError("[DragSizeConsole][Awake] _rectTransform is null.");
                enabled = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
            _rectTransform.sizeDelta += eventData.delta;
        }
    }
}