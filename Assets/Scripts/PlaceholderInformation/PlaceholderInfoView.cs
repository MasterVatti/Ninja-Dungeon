using System.Collections.Generic;
using BuildingSystem;
using ResourceSystem;
using UnityEngine;


public class PlaceholderInfoView : MonoBehaviour
{
    [SerializeField] 
    private RequiredResourcesView requiredResourcesViewPrefab;
    [SerializeField] 
    private List<ResourceImage> _resourceImages = new List<ResourceImage>();// TODO: удалить после того как появится IconsProvider

    private List<Resource> _requiredResourceList;
    private List<Resource> _currentResourceList;
    private Dictionary<ResourceType, RequiredResourcesView> _requiredResourceViews;
    private BuildingController _usingPlaceholder;

    public void Initialize(BuildingController placeholder)
    {
        _usingPlaceholder = placeholder;
        Vector3 uiPosition = placeholder.GetComponent<Transform>().position;
        transform.position += uiPosition;
        
        _requiredResourceViews = new Dictionary<ResourceType, RequiredResourcesView>();
        placeholder.OnPayForBuilding += OnPayForBuilding;
        _currentResourceList = placeholder.RequiredResource;
        _requiredResourceList = placeholder.BuildingSettings.RequiredResources;
        AddPieceToView(uiPosition);
    }

    private void AddPieceToView(Vector3 uiPosition)
    {
        foreach (var resource in _requiredResourceList)
        {
            var placeholderInfoView=Instantiate(requiredResourcesViewPrefab,uiPosition, Quaternion.identity, transform);
            _requiredResourceViews.Add(resource.Type,placeholderInfoView);
            placeholderInfoView.Initialize(resource,GetResourceSprite(resource));
        }
    }

    private Sprite GetResourceSprite(Resource resource)
    {
        foreach (var resourceImage in _resourceImages)
        {
            if (resourceImage.Type == resource.Type)
            {
                return resourceImage.Sprite;
            }
        }

        return null;
    }

    private void OnPayForBuilding()
    {
        foreach (var resource in _currentResourceList)
        {
            _requiredResourceViews[resource.Type].ShowPlaceholderInformation(resource);
        }
    }

    private void OnDestroy()
    {
       _usingPlaceholder.OnPayForBuilding -= OnPayForBuilding;
    }
}
