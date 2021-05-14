using System.Collections.Generic;
using System.Linq;
using Buildings.PlayerCharacteristicsImprove;
using BuildingSystem;
using Characteristics;
using Newtonsoft.Json;
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSaveConfig : ScriptableObject
    {
        public BuildingData[] Buildings => StartConstructions;
        public List<Resource> Resources => _startResources;
        public List<CharacteristicType> Characteristics => _defaultCharacteristics.Characteristics;

        private BuildingData[] StartConstructions
        {
            get
            {
                var constructions = _startBuildings.Select(building => new BuildingData
                {
                    SettingsID = building.ID,
                    State = ""
                }).ToList();
                constructions.AddRange(_startPlaceHolders.Select(placeHolder => new BuildingData
                {
                    SettingsID = placeHolder.ID, 
                    State = JsonConvert.SerializeObject(new PlaceHolderData
                    {
                        RemainResources = placeHolder.UpgradeList[0].UpgradeCost
                    })
                }));

                return constructions.ToArray();
            }
        }

        [SerializeField]
        private List<Resource> _startResources;
        [SerializeField]
        private BuildingSettings[] _startBuildings;
        [SerializeField]
        private BuildingSettings[] _startPlaceHolders;
        [SerializeField]
        private DefaultCharacteristics _defaultCharacteristics;
    }
}
