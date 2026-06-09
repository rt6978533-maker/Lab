using UnityEngine;

namespace Game.Player.Weapon
{
    [AddComponentMenu("Game/Player/Weapon/WeaponManager")]
    public class WeaponManager : MonoBehaviour
    {
        public Weapon[] Weapons;

        private Weapon GetWeapon(int index)
        {
            if (Weapons.Length <= index || index < 0)
            {
                Debug.LogError("[WeaponManager][GetWeapon] Weapons[]: ArgumentOutOfRangeException(" + index + ")");
                return null;
            }

            Weapon weapon = Weapons[index];

            if (weapon == null)
            {
                Debug.LogError($"[WeaponManager][GetWeapon] Weapons[{index}] is null.");
                return null;
            }

            return weapon;
        }

        public void EnableWeapon(int index) => GetWeapon(index)?.Enable();
        public void DisableWeapon(int index) => GetWeapon(index)?.Disable();
    }
}