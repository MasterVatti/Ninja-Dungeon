using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using BuildingSystem;
using ResourceSystem;
using UnityEngine;
/// <summary>
/// Класс отвечает за анимацию передачи ресурсов в указанную точку на Canvas.
/// </summary>
public class AmimationToGUI : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    
    [SerializeField]
    private int _countFlyingResourses = 5;

    [SerializeField] 
    private float _delayFlyingResourses = 0.2f;

    [SerializeField]
    private ResourceMiner _resourceMiner;
    
    private float _time = 1;

    private void Start()
    {
        _resourceMiner.OnTakeResources += TakeResourcesFromBuilding;
    }

    private void TakeResourcesFromBuilding(ResourceType resourceType)
    {
        
        StartCoroutine(MoveResource(resourceType));
        
    }

    private Transform GetPositionViewResource(ResourceType resourceType)
    {
        var resourceView = MainManager.ViewManager.ResourcesView.ResourceLabels;
        
        foreach (var positionLabel in resourceView)
        {
            if (positionLabel.Type == resourceType)
            {
                return positionLabel.Label.transform;
            }
        }
        
        return null;
    }
    
    private IEnumerator MoveResource(ResourceType resourceType)
    {
        var positionView = GetPositionViewResource(resourceType);
        
        for (int i = 0; i < _countFlyingResourses; i++)
        {
            MainManager.AnimationManager.ShowFlyingResource(resourceType, transform.position, 
                positionView.position, true);
            yield return new WaitForSeconds(_delayFlyingResourses);
        }
        
    }

    private void OnDestroy()
    {
        _resourceMiner.OnTakeResources -= TakeResourcesFromBuilding;
    }
}
