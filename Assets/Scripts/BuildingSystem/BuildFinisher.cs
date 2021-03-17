using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Класс содержит методы, которые нужно выполнить по окончанию строительства:
    /// разблокирует новые места для строительства
    /// разблокирует построенное здание
    /// </summary>
    public class BuildFinisher : MonoBehaviour
    {
        [SerializeField]
        private BuildingController _buildingController;
        private BuildingSettings _buildingSettings;

        private void Start ()
        {
            _buildingController.OnBuildFinished += CreatePlaceHolders;
            _buildingController.OnBuildFinished += CreateBuilding;
            _buildingController.OnBuildFinished += DestroyPlaceHolder;
            _buildingSettings = _buildingController.BuildingSettings;
        }

        private void CreatePlaceHolders ()
        {
            var placeHolders = _buildingSettings.ConnectedPlaceHolders;
            if(placeHolders != null)
            {
                foreach (var placeHolder in placeHolders)
                {
                    BuildingController.CreateNewBuilding(placeHolder, true);
                }
            }
        }

        private void CreateBuilding ()
        {
            BuildingController.CreateNewBuilding(_buildingSettings, false);
        }

        private void DestroyPlaceHolder ()
        {
            Destroy(gameObject);
        }

        private void OnDestroy ()
        {
            _buildingController.OnBuildFinished -= CreatePlaceHolders;
            _buildingController.OnBuildFinished -= CreateBuilding;
            _buildingController.OnBuildFinished -= DestroyPlaceHolder;
        }
    }
}
