using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using Barracks_and_allied_behavior;
using BuildingSystem;
using Characteristics;
using SaveSystem;
using UnityEngine;

namespace NinjaDungeon.Scripts.AI.Ally
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
        [SerializeField]
        private Vector3 _spawnOffset = Vector3.forward;
        
        private int _createdAllyID;

        public void CreateAlly(AlliesSetting ally)
        {
            _createdAllyID = _allies.IndexOf(ally);
            var createdAlly = Instantiate(ally.AllyPrefab, _spawnPoint.position, Quaternion.identity);
            MainManager.Player.SetAlly(createdAlly.GetComponent<Person>());
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
            if (data == null)
            {
                return;
            }
            
            _createdAllyID = data.ID;
            var allyPrefab = _allies[_createdAllyID].AllyPrefab;
            var spawnPoint = MainManager.Player.transform.position + _spawnOffset;
            var createdAlly = Instantiate(allyPrefab, spawnPoint, Quaternion.identity);
            MainManager.Player.SetAlly(createdAlly.GetComponent<Person>());
        }

        public override void OnUpgrade(BarrackData oldBuildingState)
        {
        }

        public override BarrackData GetState()
        {
            if (MainManager.Player.Ally != null)
            {
                return new BarrackData
                {
                    ID = _createdAllyID
                };
            }

            return null;
        }
    }
}