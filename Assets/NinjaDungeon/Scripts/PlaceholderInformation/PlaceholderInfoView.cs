using System.Collections.Generic;
using BuildingSystem;
using ResourceSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaceholderInfoView : BuildingInfoView
{
    private const int PLACEHOLDER_UPGRADE_LEVEL = 0;

    [FormerlySerializedAs("requiredResourcesViewPrefab")]
    [SerializeField]
    private RequiredResourcesView _requiredResourceView;

    [SerializeField]
    private Transform _requiredResourcesRoot;

    private readonly Dictionary<ResourceType, RequiredResourcesView> _requiredResourceViews  = new Dictionary<ResourceType, RequiredResourcesView>();
    private BuildingPlaceholder _buildingPlaceholder;

    public override void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
    {
        base.Initialize(building, uiAttachPoint, nameBuilding);
        Initialize(building.GetComponent<BuildingPlaceholder>());
    }

    private void Initialize(BuildingPlaceholder buildingPlaceholder)
    {
        _buildingPlaceholder = buildingPlaceholder;

        transform.position = buildingPlaceholder.PositionUI.transform.position;

        AddRequiredResourcesViews();
        UpdateResources();
        
        buildingPlaceholder.OnPayForBuilding += UpdateResources;
    }

    private void AddRequiredResourcesViews()
    {
        var requiredResources = _buildingPlaceholder.BuildingSettings.GetUpgradeCost(PLACEHOLDER_UPGRADE_LEVEL);

        foreach (var resource in requiredResources)
        {
            var placeholderInfoView = Instantiate(_requiredResourceView, _requiredResourcesRoot);
            var resourceIcon = MainManager.IconsProvider.GetResourceSprite(resource.Type);
            placeholderInfoView.Initialize(resource, resourceIcon);
            
            _requiredResourceViews.Add(resource.Type, placeholderInfoView);
        }
    }

    private void UpdateResources()
    {
        foreach (var resource in _buildingPlaceholder.RequiredResource)
        {
            _requiredResourceViews[resource.Type].ShowPlaceholderInformation(resource);
        }
    }

    private void OnDestroy()
    {
        _buildingPlaceholder.OnPayForBuilding -= UpdateResources;
    }
}