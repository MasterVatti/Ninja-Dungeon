using System.Collections.Generic;
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
    
        private List<HealthBar> _healthBars;

        private void Awake()
        {
            _healthBars = new List<HealthBar>();
        }

        public HealthBar CreateHealthBar()
        {
            var healthBar = Instantiate(_healthBarPrefab, transform.position, transform.rotation,
                _canvas.transform);
            _healthBars.Add(healthBar);
            return healthBar;
        }
    }
}
