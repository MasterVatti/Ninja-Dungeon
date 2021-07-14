using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using Characteristics;
using ExperienceSystem;
using Newtonsoft.Json;
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSaveConfig : ScriptableObject
    {
        public SaveBuildings DefaultSaveBuildings => new SaveBuildings(StartConstructions);
        public SaveResources DefaultSaveResources => new SaveResources(_startResources.ToArray());
        public SavePlayer DefaultSavePlayer => new SavePlayer(PlayerData);

        private PlayerData PlayerData
        {
            get
            {
                var playerCharacteristics = (PlayerCharacteristics) MainManager.Player.PersonCharacteristics;
                var maximumExperienceLevelUpperWorld = playerCharacteristics.MaximumExperienceLevelUpperWorld;
                var playerData = new PlayerData
                {
                    LevelUpperWorld = 0,
                    ExperienceUpperWorld = 0,
                    MaximumExperienceLevelUpperWorld = maximumExperienceLevelUpperWorld
                };

                return playerData;
            }
        }

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
