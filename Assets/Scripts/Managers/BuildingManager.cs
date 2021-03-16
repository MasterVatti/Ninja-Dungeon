using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public List<BuildingSettings> ActiveBuildings
        {
            get => _activeBuildings;
            set => _activeBuildings = value;
        }
        
        [SerializeField]
        private List<BuildingSettings> _activeBuildings = new List<BuildingSettings>();

        private void Start()
        {
            foreach (var building in _activeBuildings)
            {
                var go = Instantiate(building.PlaceHolderPrefab, building.PlaceHolder, Quaternion.identity);
                go.GetComponent<BuildingController>().Building = building;
            }
        }
    }
}
