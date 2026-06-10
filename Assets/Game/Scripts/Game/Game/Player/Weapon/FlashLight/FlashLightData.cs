using UnityEngine;
using UnityEngine.Events;

namespace Game.Player.Weapon.Flashlight
{
    [AddComponentMenu("Game/Player/Weapon/Flashlight/FlashlightData")]
    [RequireComponent(typeof(FlashlightPowerBinder))]
    public class FlashLightData : MonoBehaviour
    {
        public float Energy = 100;
        public float MaxEnergy = 100;

        [SerializeField] private float _energyRate = 1;

        private FlashlightPowerBinder _changeLight;

        private void Awake() => _changeLight = GetComponent<FlashlightPowerBinder>();

        public void AddEnergy(int value) {
            if (value < 0) return;

            Energy += value;
            Energy = Mathf.Clamp(Energy, 0, MaxEnergy);
            _changeLight?.Change(Energy);
        }

        private void Update()
        {
            Energy -= _energyRate * Time.deltaTime;
            Energy = Mathf.Clamp(Energy, 0, MaxEnergy);
            _changeLight?.Change(Energy);
        }
    }
}