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
        
        public List<GameObject> ActiveBuildings { get; } = new List<GameObject>();
        public List<GameObject> ActivePlaceHolders { get; } = new List<GameObject>();

        [SerializeField]
        private List<BuildingSettings> _buildings = new List<BuildingSettings>();

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
