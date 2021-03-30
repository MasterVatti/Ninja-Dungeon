using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public List<GameObject> ConstructedBuldings = new List<GameObject>();
        [SerializeField]
        private List<BuildingSettings> _startBuildings = new List<BuildingSettings>();

        private void Start()
        {
            foreach (var placeHolder in _startBuildings)
            {
                BuildingController.CreateNewBuilding(placeHolder, true);
            }
        }
    }
}
