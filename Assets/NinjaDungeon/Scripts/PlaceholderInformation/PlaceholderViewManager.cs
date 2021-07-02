using System.Collections.Generic;
using BuildingSystem;
using NinjaDungeon.Scripts.Managers;
using UnityEngine;

public class PlaceholderViewManager : MonoBehaviour
{
    [SerializeField] 
    private PlaceholderInfoView _placeholderViewPrefab;

    private Dictionary<GameObject, PlaceholderInfoView> _placeholderInfoViews;

    private void Start()
    {
        _placeholderInfoViews = new Dictionary<GameObject, PlaceholderInfoView>();
        
        var constructedPlaceholders = UpperWorldManager.BuildingManager.GetActivePlaceholders();
        foreach (var placeholder in constructedPlaceholders)
        {
            AddPlaceholderView(placeholder);
        }

        UpperWorldManager.BuildingManager.OnPlaceholderDestroyed += RemovePlaceholderView;
        UpperWorldManager.BuildingManager.OnPlaceholderCreated += AddPlaceholderView;
    }

    private void AddPlaceholderView(GameObject placeholder)
    {
        var placeholderView = Instantiate(_placeholderViewPrefab, transform);
        
        var buildingPlaceholder = placeholder.GetComponent<BuildingPlaceholder>();
        placeholderView.Initialize(placeholder, buildingPlaceholder.PositionUI, buildingPlaceholder.BuildingSettings.BuildingName);
        
        _placeholderInfoViews.Add(placeholder, placeholderView);
    }

    private void RemovePlaceholderView(GameObject placeholder)
    {
        Destroy(_placeholderInfoViews[placeholder].gameObject);
        _placeholderInfoViews.Remove(placeholder);
    }

    private void OnDestroy()
    {
        UpperWorldManager.BuildingManager.OnPlaceholderDestroyed -= RemovePlaceholderView;
        UpperWorldManager.BuildingManager.OnPlaceholderCreated -= AddPlaceholderView;
    }
}