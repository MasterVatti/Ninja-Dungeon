using System.Collections.Generic;
using BuildingSystem;
using UnityEngine;
namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField]
        private List<BuildingSettings> _startPlaceHolders = new List<BuildingSettings>();

        private void Start()
        {
            foreach (var placeHolder in _startPlaceHolders)
            {
                BuildingController.CreateNewBuilding(placeHolder, true);
            }
        }
    }
}
