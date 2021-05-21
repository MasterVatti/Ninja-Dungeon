using UnityEngine;

namespace Energy
{
    /// <summary>
    /// Отвечает за управление энергией
    /// </summary>
    public class EnergyManager : MonoBehaviour
    {
        public int Energy => _energyCount;
    
        [SerializeField]
        private int _energyCount = 100;
        [SerializeField]
        private int _maximalEnergy = 100;

        private void Awake()
        {
            _energyCount = Mathf.Clamp(_energyCount, 0, _maximalEnergy);
        }

        private void OnDestroy()
        {
            DontDestroyOnLoad(gameObject);
        }
    
        public void DecreaseEnergy(int decreaseNumber)
        {
            _energyCount = Mathf.Clamp(_energyCount -= decreaseNumber, 0, _maximalEnergy);
        }

        public void IncreaseEnergy(int increaseNumber)
        {
            _energyCount = Mathf.Clamp(_energyCount += increaseNumber, 0, _maximalEnergy);
        }
    }
}
