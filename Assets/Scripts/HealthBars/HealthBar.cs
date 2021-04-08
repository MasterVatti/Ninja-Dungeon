using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] 
        private Vector3 _noramlizePosition;
        
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

        public void NormalizePosition(Vector3 entityToAttach)
        {
            transform.position = entityToAttach + _noramlizePosition;
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
