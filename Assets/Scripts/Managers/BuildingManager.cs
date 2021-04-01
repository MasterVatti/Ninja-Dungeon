using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
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
    }
}
