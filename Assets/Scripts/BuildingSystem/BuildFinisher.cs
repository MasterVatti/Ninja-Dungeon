using System.Collections.Generic;

namespace BuildingSystem
{
    /// <summary>
    /// Класс содержит методы, которые нужно выполнить по окончанию строительства:
    /// разблокирует новые места для строительства
    /// разблокирует построенное здание
    /// </summary>
    public class BuildFinisher
    {
        private readonly BuildingSettings _buildingSettings;
        private readonly List<BuildingSettings> _placeHolders;
        public BuildFinisher(BuildingSettings settings, List<BuildingSettings> placeHolders)
        {
            _buildingSettings = settings;
            _placeHolders = placeHolders;
        }
        public void FinishBuilding()
        {
            CreatePlaceHolders(_placeHolders);
            CreateBuilding(_buildingSettings);
        }
        
        private void CreateBuilding (BuildingSettings buildingSettings)
        {
            BuildingController.CreateNewConstruction(buildingSettings, true);
        }

        private void CreatePlaceHolders (List<BuildingSettings> placeHolders)
        {
            if(placeHolders != null)
            {
                foreach (var placeHolder in placeHolders)
                {
                    BuildingController.CreateNewConstruction(placeHolder, false);
                }
            }
        }
    }
}
