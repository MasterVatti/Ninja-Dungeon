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
        
        private Slider _slider;
        private HealthBehavior _healthBehaviorToAttach;
        
        private void OnEnable()
        {
            _slider = GetComponent<Slider>();
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
                Destroy(gameObject);
            }
        }

        private void SetMaximalHealth(int health)
        {
            _slider.maxValue = health;
            _slider.value = health;
        }

        private void SetHealthBarValue(int health)
        {
            _slider.value = health;
        }

        private void StabilizatePosition(Vector3 entityPositionToAttach)
        {
            transform.position = entityPositionToAttach + _stabilizateToPosition;
        }
        
        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
