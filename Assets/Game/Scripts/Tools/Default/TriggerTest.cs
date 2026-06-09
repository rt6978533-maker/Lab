using UnityEngine;
using UnityEngine.Events;

namespace Tools.Default
{
    [AddComponentMenu("Tools/Default/TriggerTest")]
    public class TriggerTest : MonoBehaviour
    {
        enum FilterTrigger { None, Name, Tag}

        [HideInInspector] public bool IsEnabled = true;

        [SerializeField] private FilterTrigger _filter;
        public string ValueFilter;
        public UnityEvent<GameObject> IsTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsEnabled) return;

            GameObject g = other.gameObject;

            switch (_filter)
            {
                case FilterTrigger.None: IsTriggered?.Invoke(g); return;
                case FilterTrigger.Name: 
                    if (g.name == ValueFilter) IsTriggered?.Invoke(g);
                    return;
                case FilterTrigger.Tag: 
                    if (g.CompareTag(ValueFilter)) IsTriggered?.Invoke(g);
                    return;
            }
        }

        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
    }
}