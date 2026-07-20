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
        public string Bloom(float intensity) {
            if (_bloom == null) return "[ConsolePostProcessing] _bloom is null pls check in editor.";
            _bloom.intensity.value = intensity;

            return "Postprocessing-Bloom intensity: " + intensity;
        }

        [ConsoleCommand("postprocessing-lens_Distortion")]
        public string LensDistortion(float intensity) {
            if (_lensDistortion == null) return "[ConsolePostProcessing] _lensDistortion is null pls check in editor.";
            _lensDistortion.intensity.value = intensity;

            return "Postprocessing-Lens_Distortion intensity: " + intensity;
        }
    }
}