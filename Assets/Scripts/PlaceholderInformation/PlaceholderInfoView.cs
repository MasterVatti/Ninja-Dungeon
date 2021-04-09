using System;
using System.Collections;
using System.Collections.Generic;
using BuildingSystem;
using Managers;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaceholderInfoView : MonoBehaviour
{
    [SerializeField] 
    private PieceOfPlaceholderInfoView _pieceOfPlaceholderInfoViewPrefab;
    [SerializeField] 
    private List<ResourceImage> _resourceImages = new List<ResourceImage>();

    private List<Resource> _requiredResourceList;
    private List<Resource> _currentResourceList;
    private Dictionary<ResourceType, PieceOfPlaceholderInfoView> _resourceForPiece;

    public void Initialize(BuildingController placeholder)
    {
        Vector3 uiPosition = placeholder.GetComponent<Transform>().position;
        transform.position += uiPosition;
        
        _resourceForPiece = new Dictionary<ResourceType, PieceOfPlaceholderInfoView>();
        placeholder.OnPayForBuilding += ResourceAdded;
        _currentResourceList = placeholder.RequiredResource;
        _requiredResourceList = placeholder.BuildingSettings.RequiredResources;
        AddPieceToView(uiPosition);
    }

    private void AddPieceToView(Vector3 uiPosition)
    {
        foreach (var resource in _requiredResourceList)
        {
            var pieceOfPlaceholderInfoView=Instantiate(_pieceOfPlaceholderInfoViewPrefab,uiPosition, Quaternion.identity, transform);
            _resourceForPiece.Add(resource.Type,pieceOfPlaceholderInfoView);
            pieceOfPlaceholderInfoView.Initialize(resource,GetResourceSprite(resource));
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

    private void ResourceAdded()
    {
        foreach (var resource in _currentResourceList)
        {
            _resourceForPiece[resource.Type].ShowPlaceholderInformation(resource);
        }
    }
}
