using Enemies;
using UnityEngine;

namespace HealthBars
{
    /// <summary>
    /// отвечает за хелсбар, который висит на 
    /// </summary>
    public class HealthBarOnEnemy : MonoBehaviour
    {
        [SerializeField]
        private HealthBarsManager _healthBarsManager;
    
        private HealthBar _healthBar;
        private HealthBehavior _healthBehavior;
        private int _health;
    
        private void Awake()
        {
            _healthBehavior = GetComponent<HealthBehavior>();
            _health = _healthBehavior.Health;
            _healthBar = _healthBarsManager.CreateHealthBar();
            _healthBar.SetMaximalHealth(_health);
            _healthBar.StabilizatePosition(transform.position);
            _healthBehavior.HealthBarValueDecrease += SetValueOnHealthBar;
        }
    
        private void Update()
        {
            _healthBar.StabilizatePosition(transform.position);
        }

        private void OnDestroy()
        {
            _healthBehavior.HealthBarValueDecrease -= SetValueOnHealthBar;
        }

        private void SetValueOnHealthBar(int health)
        {
            _healthBar.SetHealthBarValue(health);
            if (health <= 0)
            {
                _healthBar.Destroy();
            }
        }
    }
}
