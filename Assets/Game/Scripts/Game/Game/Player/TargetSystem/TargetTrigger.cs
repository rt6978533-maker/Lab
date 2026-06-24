using UnityEngine;

namespace Game.Player.Target
{
    [AddComponentMenu("Game/Player/Target/TargetTrigger")]
    public sealed class TargetTrigger : MonoBehaviour
    {
        [SerializeField] private string _messageTarget;
        [SerializeField] private bool _destroyTrigger = false;
        [SerializeField] private bool _multipleTrigger = false;

        bool _state = false;

        private void OnTriggerEnter(Collider other)
        {
            if (_multipleTrigger == false && _state) return;

            if (other.TryGetComponent(out TargetSystem targetSystem))
            {
                targetSystem.SetTarget(_messageTarget);
                _state = true;

                if (_destroyTrigger) Destroy(gameObject);
            }
        }
    }
}