using System.Collections.Generic;
using Characteristics;
using Managers;
using UnityEngine;

namespace HealthBehaviors
{
    /// <summary>
    /// отвечает за систему хелсбаров
    /// </summary>
    public class HealthBarsManager : MonoBehaviour
    {
        public List<HealthBar> HealthBars => _healthBars;
        
        [SerializeField]
        private HealthBar _healthBarPrefab;
        [SerializeField] 
        private Canvas _canvas;
        [SerializeField] 
        private CharacteristicsManager _characteristicsManager;
        
        private List<HealthBar> _healthBars = new List<HealthBar>();
        private int _currentHealthBehaviorToAttach = -1;

        private void Awake()
        {
            for (int i = 0; i < _characteristicsManager.CharacteristicsAllUnits.Count; i++)
            {
                CreateHealthBar();
            }
        }

        public PersonCharacteristics InitCharacteristicToAttach()
        {
            ++_currentHealthBehaviorToAttach;
            return _characteristicsManager.CharacteristicsAllUnits[_currentHealthBehaviorToAttach].GetComponent<PersonCharacteristics>();
        }
        
        private void CreateHealthBar()
        {
            var healthBar = Instantiate(_healthBarPrefab, transform.position, transform.rotation,
                _canvas.transform);
            
            MainManager.HealthBarsManager._healthBars.Add(healthBar);
        }
    }
}