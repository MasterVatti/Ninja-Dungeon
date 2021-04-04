using System.Collections.Generic;
using UnityEngine;
using BuildingSystem;

/// <summary>
/// Класс распределяет зданиям с ResourceMiner UI для показа ресурсов текущие/максимум
/// </summary>
public class MinerViewsManager : MonoBehaviour
{
    [SerializeField]
    private List<ResourceImage> _resourceImages = new List<ResourceImage>();
    [SerializeField]
    private MinerView _minerViewPrefab;
    

    void Start()
    {
        var constructedBuildings = MainManager.BuildingManager.ConstructedBuldings;
        foreach (var building in constructedBuildings)
        {
            AddUIToBuilding(building);
        }

        MainManager.BuildingManager.OnBuildFinished += AddUIToBuilding;
    }

    private void AddUIToBuilding(GameObject building)
    {
        if (building.TryGetComponent(out ResourceMiner miner))
        {
            CreateAccumulatedResourceUI(miner,miner.PositionUI);
        }
    }
    
    private void CreateAccumulatedResourceUI(ResourceMiner resourceMiner,Transform UIposition)
    {
        var accumulatedResource = Instantiate(_minerViewPrefab,transform);
        
        accumulatedResource.Initilize(resourceMiner,UIposition.position,GetResourceSprite(resourceMiner));
    }

    private Sprite GetResourceSprite(ResourceMiner resourceMiner)
    {
        foreach (var resource in _resourceImages)
        {
            if (resource.Type == resourceMiner.ExtractableResource)
            {
                return resource.Sprite;
            }
        }

        return null;
    }

    private void OnDisable()
    {
        if (MainManager.BuildingManager != null)
        {
            MainManager.BuildingManager.OnBuildFinished -= AddUIToBuilding;
        }
    }
}
