using Core.Vibrations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class ImageStateToggle : MonoBehaviour
    {
        [SerializeField] [Required] private Image _turnedOnImage;
        [SerializeField] [Required] private Button _button;
        private VibrationsReproducer _vibrationsReproducer;

        public void Construct(VibrationsReproducer vibrationsReproducer)
        {
            _vibrationsReproducer = vibrationsReproducer;
        }

        private void Start()
        {
            UpdateStrikethrough();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ToggleVibrations);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ToggleVibrations);
        }

        private void ToggleVibrations()
        {
            _vibrationsReproducer.Enabled = !_vibrationsReproducer.Enabled;
            UpdateStrikethrough();
        }

        private void UpdateStrikethrough()
        {
            _turnedOnImage.gameObject.SetActive(_vibrationsReproducer.Enabled);
        }
    }
}