using System.Linq;
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
            if (building.TryGetComponent(out ResourceMiner miner))
            {
                CreateUIAccumulatedResource(miner,building.GetComponent<TemporaryClassBuilding>().PositionUI);
            }
        }

        _buildingController.OnBuildFinished += NewBuiltBuilding;
    }

    private void NewBuiltBuilding(GameObject building)
    {
        if (building.TryGetComponent(out ResourceMiner miner))
        {
            CreateUIAccumulatedResource(miner,building.GetComponent<TemporaryClassBuilding>().PositionUI);
        }
    }
    
    private void CreateUIAccumulatedResource(ResourceMiner resourceMiner,Transform UIposition)
    {
        var accumulatedResource = Instantiate(_accumulatedResourcesUIPrefab,transform);
        accumulatedResource.Initilize(resourceMiner,UIposition);
    }

    private void OnDestroy()
    {
        _buildingController.OnBuildFinished -= NewBuiltBuilding;
    }
}
