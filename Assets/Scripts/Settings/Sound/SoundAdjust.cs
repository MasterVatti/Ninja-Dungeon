using UnityEngine;
using UnityEngine.UI;

namespace Settings.Sound
{
    public class SoundAdjust : MonoBehaviour
    {
        [SerializeField] 
        private Slider _currentSlider;

        public float PreviousSound
        {
            get => _previousSound;
            set => _previousSound = value;
        }

        private float _previousSound;

        public void OnValueChanged()
        {
            SoundChange();
        }

        private void SoundChange()
        {
            _previousSound = _currentSlider.value;
            AudioListener.volume = _previousSound;
        }
    }
}
