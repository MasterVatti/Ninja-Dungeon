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
        public event Action<GameObject> OnPlaceholderDestroy;
        public event Action<GameObject> OnPlaceholderCreated; 
        
        public List<GameObject> ActiveBuildings { get; } = new List<GameObject>();
        public List<GameObject> ActivePlaceHolders { get; } = new List<GameObject>();

        [SerializeField]
        private List<BuildingSettings> _buildings = new List<BuildingSettings>();

        public BuildingSettings GetBuildingSettings(int buildingID)
        {
            return _buildings.FirstOrDefault(building => building.ID == buildingID);
        }

        public void DestroyPlaceholder(GameObject placeholder)
        {
            ActivePlaceHolders.Remove(placeholder);
            OnPlaceholderDestroy?.Invoke(placeholder);
        }

        public void AddNewPlaceholder(GameObject placeholder)
        {
            ActivePlaceHolders.Add(placeholder);
            OnPlaceholderCreated?.Invoke(placeholder);
        }
        
        public void AddNewConstructedBuilding(GameObject building)
        {
            ActiveBuildings.Add(building);
            OnBuildFinished?.Invoke(building);
        }
    }
}
