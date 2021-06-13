using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public event Action <GameObject, BuildingSettings> OnBuildFinished;

        public List<GameObject> ActiveBuildings => _activeBuildings;

        public List<GameObject> ActivePlaceHolders => _activePlaceHolders;

        [SerializeField]
        private List<BuildingSettings> _buildings = new List<BuildingSettings>();
        [SerializeField]
        private List<GameObject> _activePlaceHolders = new List<GameObject>();
        [SerializeField]
        private List<GameObject> _activeBuildings = new List<GameObject>();

        private void Start()
        {
            for(var i = 0; i < _buildings.Count; i++)
            {
                _buildings[i].ID = i;
            }
        }

        public BuildingSettings GetBuildingSettings(int buildingID)
        {
            return _buildings.FirstOrDefault(building => building.ID == buildingID);
        }

        public void AddNewConstructedBuilding(GameObject building, BuildingSettings buildingSettings)
        {
            ActiveBuildings.Add(building);
            OnBuildFinished?.Invoke(building, buildingSettings);
        }
    }
}
