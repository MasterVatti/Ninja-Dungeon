using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using Newtonsoft.Json;
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSaveConfig : ScriptableObject
    {
        public Save DefaultSave => new Save
        {
            Buildings = StartConstructions,
            Resources = new List<Resource>(_startResources).ToArray(),
        };

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
                        RemainResources = placeHolder.UpgradesInfo[0].UpgradeCost
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
    }
}
