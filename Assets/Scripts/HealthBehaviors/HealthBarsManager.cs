using System.Collections.Generic;
using UnityEngine;

namespace HealthBehaviors
{
    /// <summary>
    /// отвечает за систему хелсбаров
    /// </summary>
    public class HealthBarsManager : MonoBehaviour
    {
        [SerializeField]
        private HealthBar _healthBarPrefab;
        [SerializeField] 
        private Canvas _canvas;
        [SerializeField] 
        private HealthBehaviorsManager _healthBehaviorsManager;
        
        private List<HealthBar> _healthBars = new List<HealthBar>();
        private int _currentHealthBehaviorToAttach;

        private void Awake()
        {
            for (int i = 0; i < _healthBehaviorsManager.HealthBehaviors.Count - 1; i++)
            {
                CreateHealthBar();
            }
        }

        public HealthBehavior InitHealthBehaviorToAttach()
        {
            _currentHealthBehaviorToAttach++;
            return _healthBehaviorsManager.HealthBehaviors[_currentHealthBehaviorToAttach - 1];
        }
        
        private void CreateHealthBar()
        {
            var healthBar = Instantiate(_healthBarPrefab, transform.position, transform.rotation,
                _canvas.transform);
            
            _healthBars.Add(healthBar);
        }
    }
}
