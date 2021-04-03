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

        public BuildingSettings GetBuildingSettings(int buildingID)
        {
            return _buildings.FirstOrDefault(building => building.ID == buildingID);
        }
    }
}
