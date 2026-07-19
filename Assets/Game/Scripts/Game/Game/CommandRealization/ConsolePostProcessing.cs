using UnityEngine;
using Game.NewConsole;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Game.CommandRealization
{
    [AddComponentMenu("Game/CommandRealization/ConsolePostProcessing")]
    public class ConsolePostProcessing : MonoBehaviour
    {
        [SerializeField] private Volume _settings;
        private Bloom _bloom;
        private LensDistortion _lensDistortion;

        private void Awake()
        {
            if (_settings == null)
            {
                throw new System.NullReferenceException(nameof(_settings));
            }

            if (_settings.profile.TryGet(out Bloom bloom)) _bloom = bloom;
            if (_settings.profile.TryGet(out LensDistortion lensDistortion)) _lensDistortion = lensDistortion;
        }

        [ConsoleCommand("postprocessing-bloom")]
        public void Bloom(float intensity) {
            if (_bloom == null) return;
            _bloom.intensity.value = intensity;
        }

        [ConsoleCommand("postprocessing-Lens_Distortion")]
        public void LensDistortion(float intensity) {
            if (_lensDistortion == null) return;
            _lensDistortion.intensity.value = intensity;
        }
    }
}