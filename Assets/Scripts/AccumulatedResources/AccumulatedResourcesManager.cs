using BuildingSystem;
using UnityEngine;

/// <summary>
/// Класс распределяет зданиям с ResourceMiner UI для показа ресурсов текущие/максимум
/// </summary>
public class AccumulatedResourcesManager : MonoBehaviour
{
    [SerializeField]
    private BuildingController _buildingController;
    [SerializeField]
    private UIAccumulatedResources _accumulatedResourcesUIPrefab;

    void Start()
    {
        var constructedBuildings = MainManager.BuildingManager.ConstructedBuldings;
        foreach (var building in constructedBuildings)
        {
            CheckObjectOnMiner(building);
        }

        _buildingController.OnBuildFinished += CheckObjectOnMiner;
    }

    private void CheckObjectOnMiner(GameObject building)
    {
        if (building.TryGetComponent(out ResourceMiner miner))
        {
            CreateAccumulatedResourceUI(miner,miner.PositionUI);
        }
    }
    
    private void CreateAccumulatedResourceUI(ResourceMiner resourceMiner,Transform UIposition)
    {
        var accumulatedResource = Instantiate(_accumulatedResourcesUIPrefab,transform);
        accumulatedResource.Initilize(resourceMiner,UIposition);
    }

    private void OnDestroy()
    {
        _buildingController.OnBuildFinished -= CheckObjectOnMiner;
    }
}
