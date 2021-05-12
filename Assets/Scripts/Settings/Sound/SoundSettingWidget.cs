using UnityEngine;
using UnityEngine.UI;

namespace Settings.Sound
{
    /// <summary>
    /// включить/выключить звук
    /// </summary>
    public class SoundSettingWidget : MonoBehaviour
    {
        [SerializeField] 
        private Toggle _currentToggle;
        [SerializeField] 
        private SoundAdjust _soundAdjust;
        

        private void Awake()
        {
            _soundAdjust.PreviousSound = AudioListener.volume;
        }

        public void OnValueChanged()
        {
            if (_currentToggle.isOn)
            {
                OffSound();
            }
            else
            {
                OnSound();
            }
        }

        private void OnSound()
        {
            AudioListener.volume = _soundAdjust.PreviousSound;
        }

        private void OffSound()
        {
            _soundAdjust.PreviousSound = AudioListener.volume;
            AudioListener.volume = 0;
        }
    }
}
