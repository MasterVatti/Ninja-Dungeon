using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace HealthBars
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

        public HealthBar InitHealthBar()
        {
            var healthBar = Instantiate(_healthBarPrefab, transform.position, transform.rotation,
                _canvas.transform);
            
            return healthBar;
        }

        public HealthBehavior InitHealthBehaviorToAttach()
        {
            _currentHealthBehaviorToAttach++;
            return _healthBehaviorsManager.HealthBehaviors[_currentHealthBehaviorToAttach - 1];
        }
        
        private void CreateHealthBar()
        {
            _healthBars.Add(InitHealthBar());
        }
    }
}
