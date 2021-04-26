using Enemies.Spawner;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace AccumulatedResources
{
    /// <summary>
    /// Виджет для показа времени до спавна врагов
    /// </summary>
    public class SpawnInfoView : BuildingInfoView
    {
        [SerializeField]
        private TextMeshProUGUI _timer;
        [SerializeField]
        private Slider _slider;
        
        private UpperWorldSpawner _upperWorldSpawner;
        
        public override void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
        {
            _upperWorldSpawner = building.GetComponent<UpperWorldSpawner>();
            
            base.Initialize(building, uiAttachPoint, nameBuilding);
        }
        
        protected override void Update()
        {
            base.Update();

            if (_upperWorldSpawner != null)
            {
                _slider.maxValue = _upperWorldSpawner.CooldownTime;
                
                var timeSpawn = _upperWorldSpawner.RemainTimeToSpawn;

                _slider.value = timeSpawn;
                _timer.text = timeSpawn.ToString("#");
            }
        }
    }
}
