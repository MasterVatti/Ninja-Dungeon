using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ExperienceSystem
{
    public class ExperienceView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currentLevel;
        [SerializeField]
        private Slider _slider;
        

        protected void ShowLevel(int currentLevel)
        {
            _currentLevel.text = currentLevel.ToString();
        }
        
        protected void ShowProgressExperience(int maxExperience, int currentExperience)
        {
            _slider.maxValue = maxExperience;
            _slider.value = currentExperience;
        }
    }
}