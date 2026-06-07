using GaS.Player;
using UnityEngine;

namespace Game
{
    [AddComponentMenu("Game/TriggerTeleport")]
    public class TriggerTeleport : MonoBehaviour
    {
        [SerializeField] private Transform _pos;

        private void OnTriggerEnter(Collider other)
        {
            if (_pos == null) return;

            if (other.TryGetComponent(out PlayerCharacterController plr)) {
                plr.Teleport(_pos.position);
            }
        }
    }
}