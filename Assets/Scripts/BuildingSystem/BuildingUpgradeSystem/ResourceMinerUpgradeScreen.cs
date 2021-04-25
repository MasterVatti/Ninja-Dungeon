using System.Collections.Generic;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class ResourceMinerUpgradeScreen : UpgradeScreen<MinerBuildingData>
    {
        private const string MINING_PER_SECOND_KEY = "Mining per second";
        private const string MAX_STORAGE_KEY = "Max storage";
        
        [SerializeField]
        private List<TextMeshProUGUI> _maxStorageLine = new List<TextMeshProUGUI>(TEXT_LABELS_IN_LINE);
        [SerializeField]
        private List<TextMeshProUGUI> _miningPerSecondLine = new List<TextMeshProUGUI>(TEXT_LABELS_IN_LINE);
        
        public override void ApplyContext(UpgradeContext<MinerBuildingData> context)
        {
            _building = context.Building;
        }
        
        protected override Building<MinerBuildingData> GetBuilding()
        {
            return GetComponent<Building<MinerBuildingData>>();
        }

        protected override void ShowUpgradeInfo(Dictionary<string, int> upgradeDifference)
        {
            var currentState = GetStateDictionary(_building.GetState());

            _maxStorageLine[0].text = MAX_STORAGE_KEY;
            _maxStorageLine[1].text = currentState[MAX_STORAGE_KEY].ToString();
            _maxStorageLine[2].text = "+" + upgradeDifference[MAX_STORAGE_KEY];

            _miningPerSecondLine[0].text = MINING_PER_SECOND_KEY;
            _miningPerSecondLine[1].text = currentState[MINING_PER_SECOND_KEY].ToString();
            _miningPerSecondLine[2].text = "+" + upgradeDifference[MAX_STORAGE_KEY];
        }

        protected override Dictionary<string, int> GetStateDictionary(MinerBuildingData state)
        {
            var resultDictionary = new Dictionary<string, int>
            {
                {
                    MINING_PER_SECOND_KEY, (int)state.MiningPerSecond
                },
                {
                    MAX_STORAGE_KEY, state.MaxStorage
                }
            };
            return resultDictionary;
        }
    }
}
