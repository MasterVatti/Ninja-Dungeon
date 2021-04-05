<<<<<<< Updated upstream
﻿using System.Collections.Generic;
=======
﻿using System.Linq;
using BuildingSystem;
>>>>>>> Stashed changes
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSaveConfig : ScriptableObject
    {
        public Save DefaultSave => new Save
        {
            Buildings = new List<BuildingData>(_startConstructions).ToArray(),
            Resources = new List<Resource>(_startResources).ToArray()
        };

<<<<<<< Updated upstream
=======
        private Resource[] StartResources => _startResources;

        private BuildingData[] StartConstructions
        {
            get
            {
                var constructions = _startBuildings.Select(building => new BuildingData
                {
                    IsBuilt = true,
                    SettingsID = building.ID,
                    State = ""
                }).ToList();
                constructions.AddRange(_startPlaceHolders.Select(placeHolder => new BuildingData
                {
                    IsBuilt = false,
                    SettingsID = placeHolder.ID,
                    State = ""
                }));

                return constructions.ToArray();
            }
        }

>>>>>>> Stashed changes
        [SerializeField]
        private List<Resource> _startResources;
        [SerializeField]
<<<<<<< Updated upstream
        private List<BuildingData> _startConstructions;
=======
        private BuildingSettings[] _startBuildings;
        [SerializeField]
        private BuildingSettings[] _startPlaceHolders;
>>>>>>> Stashed changes
    }
}
