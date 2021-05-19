using Characteristics;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBehaviors
{
    /// <summary>
    /// отвечает за хелсбар
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] 
        private Vector3 _stabilizateToPosition;
        [SerializeField] 
        private Slider _currentSlider;
        
        private PersonCharacteristics _characteristicsToAttach;
        private int _health;
        
        private void OnEnable()
        {
            _characteristicsToAttach = MainManager.HealthBarsManager.InitCharacteristicToAttach();
            SetMaximalHealth();
        }

        private void Update()
        {
            if (_characteristicsToAttach)
            {
                StabilizatePosition(_characteristicsToAttach.transform.position);
                SetHealthBarValue();
            }
            else
            {
                OnDestroy();
            }
        }
        
        private void SetMaximalHealth()
        {
            _health = _characteristicsToAttach.MaxHp;
            _currentSlider.maxValue = _health;
            _currentSlider.value = _health;
        }

        private void SetHealthBarValue()
        {
            _health = _characteristicsToAttach.CurrentHp;
            _currentSlider.value = _health;
        }

        private void StabilizatePosition(Vector3 entityPositionToAttach)
        {
            transform.position = entityPositionToAttach + _stabilizateToPosition;
        }
        
        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}