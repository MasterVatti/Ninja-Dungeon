using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Buildings;
using BuildingSystem;
using ResourceSystem;
using UnityEngine;
/// <summary>
/// Класс отвечает за анимацию передачи ресурсов в указанную точку на Canvas.
/// </summary>
public class AmimationToGUI : MonoBehaviour
{
    [SerializeField]
    private int _countFlyingResourses = 5;

    [SerializeField] 
    private float _delayFlyingResourses = 0.2f;

    [SerializeField]
    private ResourceMiner _resourceMiner;
    
    private float _time = 1;
    //private RectTransform _rectTransform;

    private void Start()
    {
        //_rectTransform = transform as RectTransform;
        _resourceMiner.OnTakeResources += TakeResourcesFromBuilding;
    }

    private void TakeResourcesFromBuilding(ResourceType resourceType)
    {
        
        StartCoroutine(MoveResource(resourceType));
        
    }

    private Vector3 GetPositionViewResource(ResourceType resourceType)
    {
        var resourceView = MainManager.ViewManager.ResourcesView.ResourceLabels;
        
        foreach (var positionLabel in resourceView)
        {
            if (positionLabel.Type == resourceType)
            {
                var worldPostion = transform.position;
                var screenPoint = Camera.main.WorldToScreenPoint(worldPostion);
                var accumulatedResourcesParent = positionLabel.Label.transform as RectTransform;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(accumulatedResourcesParent, 
                    screenPoint, null, out var localPoint);
                var _rectTransform = localPoint;

                return _rectTransform;
            }
        }
        return Vector3.zero;
    }
    
    private IEnumerator MoveResource(ResourceType resourceType)
    {
        var positionView = GetPositionViewResource(resourceType);
        
        for (int i = 0; i < _countFlyingResourses; i++)
        {
            MainManager.AnimationManager.ShowFlyingResource(resourceType, transform.position, 
                positionView, true);
            yield return new WaitForSeconds(_delayFlyingResourses);
        }
        
    }

    private void OnDestroy()
    {
        _resourceMiner.OnTakeResources -= TakeResourcesFromBuilding;
    }
}
