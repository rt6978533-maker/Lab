using Tools.Default;
using UnityEngine;

namespace Game.Player.Weapon
{
    [AddComponentMenu("Game/Player/Weapon/EnergyWeapon")]
    [RequireComponent(typeof(ICreatable))]
    public class EnergyWeapon : Weapon
    {
        [SerializeField, Min(0.1f)] private float _strangeBulledForce = 0.1f;

        private ICreatable _create;

        private void Awake()
        {
            _create = GetComponent<ICreatable>();

            if (_create == null) Debug.LogError("[EnergyWeapon] _create is null");
        }

        [ContextMenu("Fire")]
        public override void Fire()
        {
            if (!IsEnable) return;

            GameObject bulled = _create.GetCreate();

            if (bulled.TryGetComponent(out IAddForceBulled ibulled)) {
                ibulled.AddForce(transform.forward * _strangeBulledForce);
            } else
            {
                Debug.LogError(
                    "[EnergyWeapon] Created bullet does not have the required component (IAddForceBulled)."
                );
                Destroy(bulled);
            }
        }
    }
}