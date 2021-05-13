using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using BuildingSystem;
using SaveSystem;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за бараки, хранит список союзников. Создает союзника в определнной точке.
    /// Открывает скрин барраков.
    /// </summary>
    
    public class Barrack : Building<BarrackData>, IScreenOpenerWithContext
    {
        public List<AlliesSetting> Allies => _allies;
        
        [SerializeField]
        private List<AlliesSetting> _allies;
        [SerializeField]
        private Transform _spawnPoint;
        
        public void CreateAlly(AlliesSetting _ally)
        {
            Instantiate(_ally.AllyPrefab, _spawnPoint.position, Quaternion.identity);
        }
        
        public void ShowScreenWithContext()
        {
            var context = new BuildingContext()
            {
                Barrack = this
            };

            MainManager.ScreenManager.OpenScreenWithContext(ScreenType.BarrackScreen,
                context);
        }
        protected override void OnStateLoaded(BarrackData data)
        {
        }

        public override void OnUpgrade(BarrackData oldBuildingState)
        {
        }

        public override BarrackData GetState()
        {
            return new BarrackData();
        }
    }
}
