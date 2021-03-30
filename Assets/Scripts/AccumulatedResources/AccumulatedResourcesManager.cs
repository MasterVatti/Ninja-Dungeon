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
    private BuildingController _buildingController;
    [SerializeField]
    private UIAccumulatedResources _accumulatedResourcesUIPrefab;

    void Start()
    {
        var constructedBuildings = MainManager.BuildingManager.ConstructedBuldings;
        foreach (var bulding in constructedBuildings)
        {
            if (bulding.GetComponent<ResourceMiner>())
            {
                CreateUIAccumulatedResource(bulding.GetComponent<ResourceMiner>(),FindTagObject(bulding));
            }
        }

        _buildingController.OnBuildFinished += NewBuiltBuilding;
    }

    private void NewBuiltBuilding()
    {
        var constructedBuildings = MainManager.BuildingManager.ConstructedBuldings;
        var lastBuilding = constructedBuildings.Last();
        
        if (lastBuilding.GetComponent<ResourceMiner>())
        {
            CreateUIAccumulatedResource(lastBuilding.GetComponent<ResourceMiner>(),FindTagObject(lastBuilding));
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
