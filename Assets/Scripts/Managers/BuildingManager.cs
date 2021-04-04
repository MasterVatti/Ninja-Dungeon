using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public List<GameObject> ActiveBuildings => _activeBuildings;

        public List<GameObject> ActivePlaceHolders => _activePlaceHolders;

        [SerializeField]
        private List<BuildingSettings> _buildings = new List<BuildingSettings>();
        [SerializeField]
        private List<GameObject> _activePlaceHolders = new List<GameObject>();
        [SerializeField]
        private List<GameObject> _activeBuildings = new List<GameObject>();
        public event Action <GameObject> OnBuildFinished;
        public List<GameObject> ConstructedBuldings => _constructedBuldings;
        
        private List<BuildingSettings> _startBuildings = new List<BuildingSettings>();
        private List<GameObject> _constructedBuldings = new List<GameObject>();

        public BuildingSettings GetBuildingSettings(int buildingID)
        {
            return _buildings.FirstOrDefault(building => building.ID == buildingID);
        }

        public void AddNewConstructedBuilding(GameObject building)
        {
            ConstructedBuldings.Add(building);
            OnBuildFinished?.Invoke(building);
        }
    }
}
