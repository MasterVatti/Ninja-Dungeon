using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    /// <summary>
    /// отвечает за конкретный хелсбар
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] 
        private Vector3 _stabilizatePosition;
        
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
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
            transform.position = entityPositionToAttach + _stabilizatePosition;
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
