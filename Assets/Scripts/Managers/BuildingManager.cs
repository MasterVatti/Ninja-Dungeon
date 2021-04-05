using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public event Action <GameObject> OnBuildFinished;
        
        public List<GameObject> ActiveBuildings { get; } = new List<GameObject>();
        public List<GameObject> ActivePlaceHolders { get; } = new List<GameObject>();

        [SerializeField]
        private List<BuildingSettings> _buildings = new List<BuildingSettings>();

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

        public void AddNewConstructedBuilding(GameObject building)
        {
            ActiveBuildings.Add(building);
            OnBuildFinished?.Invoke(building);
        }
    }
}
