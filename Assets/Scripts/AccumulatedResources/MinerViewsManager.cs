using UnityEngine;
using BuildingSystem;

/// <summary>
/// Класс распределяет зданиям с ResourceMiner UI для показа ресурсов текущие/максимум
/// </summary>
public class MinerViewsManager : MonoBehaviour
{
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
        
        accumulatedResource.Initilize(resourceMiner,UIposition.position);
    }

    private void OnDisable()
    {
        if (MainManager.BuildingManager != null)
        {
            MainManager.BuildingManager.OnBuildFinished -= AddUIToBuilding;
        }
    }
}
