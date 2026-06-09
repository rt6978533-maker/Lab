using UnityEngine;

namespace Game.Player.Weapon
{
    [AddComponentMenu("Game/Player/Weapon/Bulled")]
    [RequireComponent(typeof(Rigidbody))]
    public class Bulled : MonoBehaviour, IAddForceBulled
    {
        [SerializeField, Min(0.5f)] private float _timeLife = 1.0f;

        private Rigidbody _rb;

        private void Awake() => _rb = GetComponent<Rigidbody>();

        private void Start() => Destroy(gameObject, _timeLife);

        public void AddForce(Vector3 dir)
        {
            _rb.AddForce(dir, ForceMode.Impulse);
        }
    }
}