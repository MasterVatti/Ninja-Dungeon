using System;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HealthBars
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
        
        private void Start()
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

        public void SetMaximalHealth(int health)
        {
            _slider.maxValue = health;
            _slider.value = health;
        }

        public void SetHealthBarValue(int health)
        {
            _slider.value = health;
        }

        public void StabilizatePosition(Vector3 entityPositionToAttach)
        {
            transform.position = entityPositionToAttach + _stabilizateToPosition;
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
