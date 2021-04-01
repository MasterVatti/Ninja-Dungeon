using System.Linq;
using BuildingSystem;
using UnityEngine;

/// <summary>
/// Класс распределяет зданиям с ResourceMiner UI для показа ресурсов текущие/максимум
/// местоположение определяется у дочернего объекта с тэгом "UIPositionAccumulatedResources"
/// </summary>
public class AccumulatedResourcesManager : MonoBehaviour
{
    [SerializeField]
    private Test _buildingController;
    [SerializeField]
    private UIAccumulatedResources _accumulatedResourcesUIPrefab;

    void Start()
    {
        var constructedBuildings = MainManager.BuildingManager.ConstructedBuldings;
        foreach (var building in constructedBuildings)
        {
            if (building.TryGetComponent(out ResourceMiner miner))
            {
                CreateUIAccumulatedResource(miner,FindTagObject(building));
            }
        }

        _buildingController.OnBuildFinished += NewBuiltBuilding;
    }

    private void NewBuiltBuilding(GameObject building)
    {
        if (building.TryGetComponent(out ResourceMiner miner))
        {
            CreateUIAccumulatedResource(miner,FindTagObject(building));
        }
    }
    
    private Transform FindTagObject(GameObject gameObject)
    {
        foreach (Transform childObject in gameObject.transform)
        {
            if (childObject.CompareTag("UIPositionAccumulatedResources"))
            {
                return childObject.transform;
            }
        }
        
        return null;
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
