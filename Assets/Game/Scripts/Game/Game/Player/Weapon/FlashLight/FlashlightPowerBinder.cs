using UnityEngine;

namespace Game.Player.Weapon.Flashlight
{
    [AddComponentMenu("Game/Player/Weapon/Flashlight/FlashlightPowerBinder")]
    public class FlashlightPowerBinder : MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private float _powerMax = 100;

        private float _intensity;

        private void Awake()
        {
            if (_light == null)
            {
                Debug.LogError("[FlashlightPowerBinder] _light is null");
                enabled = false;
                return;
            }

            _intensity = _light.intensity;
        }

        public void Change(float power)
        {
            float result = Mathf.Clamp(power, 0.0f, _powerMax) / _powerMax;
            _light.intensity = _intensity * result;
        }
    }
}