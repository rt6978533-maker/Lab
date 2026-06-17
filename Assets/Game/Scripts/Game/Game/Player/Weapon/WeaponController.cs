using UnityEngine;

namespace Game.Player.Weapon
{
    [AddComponentMenu("Game/Player/Weapon/WeaponController")]
    public class WeaponController : MonoBehaviour
    {
        [SerializeField, Min(0)] private int WeaponIndex = 0;

        private WeaponManager GetManager(GameObject plr)
        {
            if (plr.TryGetComponent(out WeaponManager manager)) return manager;
            else {
                Debug.LogError("[WeaponController][GetManager] Player GameObject is not exist WeaponManager.");
                return null;
            }
        }

        public void Enable(GameObject plr) => GetManager(plr).EnableWeapon(WeaponIndex);

        public void Disable(GameObject plr) => GetManager(plr).DisableWeapon(WeaponIndex);
    }
}