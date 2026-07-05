using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.System
{
    public interface IDragStart { public void OnDragStart(PointerEventData eventData); }
    public interface IDragEnd { public void OnDragEnd(PointerEventData eventData); }
    public interface IDrag { public void OnDrag(PointerEventData eventData); }

    [AddComponentMenu("Tools/System/DragSystem")]
    public class DragSystem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private IDragEnd[] _dragEnd;
        private IDragStart[] _dragStart;
        private IDrag[] _drag;

        public void OnDrag(PointerEventData eventData)
        {
            if (_drag.Length <= 0) return;
            foreach (IDrag drag in _drag) drag?.OnDrag(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_dragStart.Length <= 0) return;
            foreach (IDragStart drag in _dragStart) drag.OnDragStart(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_dragEnd.Length <= 0) return;
            foreach (IDragEnd drag in _dragEnd) drag.OnDragEnd(eventData);
        }

        private void Awake()
        {
            _drag = GetComponents<IDrag>();
            _dragStart = GetComponents<IDragStart>();
            _dragEnd = GetComponents<IDragEnd>();
        }
    }
}