using System;
using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public event Action <GameObject> OnBuildFinished;
        public List<GameObject> ConstructedBuldings => _constructedBuldings;
        
        private List<BuildingSettings> _startBuildings = new List<BuildingSettings>();
        private List<GameObject> _constructedBuldings = new List<GameObject>();

        private void Start()
        {
            foreach (var placeHolder in _startBuildings)
            {
                BuildingController.CreateNewBuilding(placeHolder, true);
            }
        }

        public void AddNewConstructedBuilding(GameObject building)
        {
            ConstructedBuldings.Add(building);
            OnBuildFinished?.Invoke(building);
        }
    }
}
