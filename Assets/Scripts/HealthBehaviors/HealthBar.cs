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
        private HealthBarsManager _healthBarsManager;
        [SerializeField] 
        private Slider _currentSlider;
        
        private HealthBehavior _healthBehaviorToAttach;
        
        private void OnEnable()
        {
            _healthBehaviorToAttach = _healthBarsManager.InitHealthBehaviorToAttach();
            SetMaximalHealth(_healthBehaviorToAttach.Health);
        }

        private void Update()
        {
            if (_healthBehaviorToAttach)
            {
                StabilizatePosition(_healthBehaviorToAttach.transform.position);
                SetHealthBarValue(_healthBehaviorToAttach.Health);
            }
            else
            {
                OnDestroy();
            }
        }

        private void SetMaximalHealth(int health)
        {
            _currentSlider.maxValue = health;
            _currentSlider.value = health;
        }

        private void SetHealthBarValue(int health)
        {
            _currentSlider.value = health;
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
