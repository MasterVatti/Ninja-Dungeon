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
            _buildingSettings = _buildingController.Building;
        }

        private void CreatePlaceHolders ()
        {
            var placeHolders = _buildingSettings.ConnectedPlaceHolders;
            if(placeHolders != null)
            {
                foreach (var placeHolder in placeHolders)
                {
                    var go = Instantiate(placeHolder.PlaceHolderPrefab, placeHolder.PlaceHolder, Quaternion.identity);
                    go.GetComponent<BuildingController>().Building = placeHolder;
                }
            }
        }

        private void CreateBuilding ()
        {
            var building = _buildingSettings.BuildingPrefab;
            var spawnPosition = _buildingSettings.PlaceHolder;
            Instantiate(building, spawnPosition, Quaternion.identity);
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
