using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField]
        private List<BuildingSettings> _startBuildings = new List<BuildingSettings>();

        private void Start()
        {
            foreach (var building in _startBuildings)
            {
                var go = Instantiate(building.PlaceHolderPrefab, building.PlaceHolderPosition, Quaternion.identity);
                go.GetComponent<BuildingController>().BuildingSettings = building;
            }
        }
    }
}
