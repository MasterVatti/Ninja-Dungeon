using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using JetBrains.Annotations;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public event Action<GameObject, BuildingSettings> OnBuildFinished;
        public event Action<GameObject> OnPlaceholderDestroyed; 
        public event Action<GameObject> OnPlaceholderCreated; 

        public List<GameObject> ActiveBuildings => _activeBuildings;
        
        [SerializeField]
        private List<BuildingSettings> _buildings = new List<BuildingSettings>();

        [SerializeField]
        private List<GameObject> _activePlaceHolders = new List<GameObject>();

        [SerializeField]
        private List<GameObject> _activeBuildings = new List<GameObject>();

        private void Awake()
        {
            for (var i = 0; i < _buildings.Count; i++)
            {
                _buildings[i].ID = i;
            }
        }
        
        public List<GameObject> GetActivePlaceholders()
        {
            //returns copy of this list
            return _activePlaceHolders.ToList();
        }

        public BuildingSettings GetBuildingSettings(int buildingID)
        {
            return _buildings.FirstOrDefault(building => building.ID == buildingID);
        }

        public void AddPlaceholder(GameObject placeholder)
        {
            _activePlaceHolders.Add(placeholder);
            OnPlaceholderCreated?.Invoke(placeholder);
        }

        private void RemovePlaceholder([CanBeNull]GameObject placeholder)
        {
            if (placeholder != null)
            {
                _activePlaceHolders.Remove(placeholder);
                OnPlaceholderDestroyed?.Invoke(placeholder);
            }
        }

        public void AddNewConstructedBuilding([CanBeNull]GameObject placeholder, 
            GameObject building, BuildingSettings buildingSettings)
        {
            RemovePlaceholder(placeholder);
            
            ActiveBuildings.Add(building);
            OnBuildFinished?.Invoke(building, buildingSettings);
        }
    }
}