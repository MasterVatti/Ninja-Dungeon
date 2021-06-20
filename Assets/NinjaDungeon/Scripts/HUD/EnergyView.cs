using System;
using Energy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class EnergyView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _energyCount;
        [SerializeField]
        private TextMeshProUGUI _energyRecovery;
        [SerializeField]
        private Slider _sliderEnergy;
        
        private EnergyManager _energyManager;

        private void Start()
        {
            _energyManager = MainManager.EnergyManager;
            _sliderEnergy.maxValue = _energyManager.MaximalEnergy;
        }
        
        private void Update()
        {
            _energyCount.text = _energyManager.CurrentEnergy + " / " + _energyManager.MaximalEnergy;
            
            var time = TimeSpan.FromSeconds(_energyManager.EnergyRecoveryTime);
            _energyRecovery.text = time.ToString(@"mm\:ss");

            _sliderEnergy.value = _energyManager.CurrentEnergy;
        }
    }
}
