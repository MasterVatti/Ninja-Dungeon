using System;
using System.Collections;
using System.Collections.Generic;
using BuildingSystem;
using Managers;
using UnityEngine;

public class PlaceholderViewManager : MonoBehaviour
{
    [SerializeField] 
    private PlaceholderInfoView _placeholderViewPrefab;

    private Dictionary<GameObject, PlaceholderInfoView> _placeholderInfoViews;

    private void Start()
    {
        _placeholderInfoViews = new Dictionary<GameObject, PlaceholderInfoView>();
        var constructedPlaceholders = MainManager.BuildingManager.ActivePlaceHolders;
        foreach (var placeholder in constructedPlaceholders)
        {
            AddUIToPlaceholder(placeholder);
        }

        MainManager.BuildingManager.OnPlaceholderDestroy += DeleteUIToPlaceholder;
        MainManager.BuildingManager.OnPlaceholderCreated += AddUIToPlaceholder;
    }

    private void AddUIToPlaceholder(GameObject placeholder)
    {
        var placeholderView = Instantiate(_placeholderViewPrefab, transform);
        var placeholderBuildingController = placeholder.GetComponent<BuildingController>();
        placeholderView.Initialize(placeholderBuildingController);
        
        _placeholderInfoViews.Add(placeholder, placeholderView);
    }

    private void DeleteUIToPlaceholder(GameObject placeholder)
    {
        Destroy(_placeholderInfoViews[placeholder].gameObject);
        _placeholderInfoViews.Remove(placeholder);
    }

    private void OnDestroy()
    {
        MainManager.BuildingManager.OnPlaceholderDestroy -= DeleteUIToPlaceholder;
        MainManager.BuildingManager.OnPlaceholderCreated -= AddUIToPlaceholder;
    }
}