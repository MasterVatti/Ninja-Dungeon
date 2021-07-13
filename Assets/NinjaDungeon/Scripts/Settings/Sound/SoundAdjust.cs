using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Settings.Sound
{
    /// <summary>
    /// Контроль звука по слайдеру
    /// </summary>
    public class SoundAdjust : MonoBehaviour
    {
        public float PreviousSound
        {
            get => _previousSound;
            set => _previousSound = value;
        }
        
        [SerializeField] 
        private Slider _currentSlider;

        private float _previousSound;

        [UsedImplicitly]
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
