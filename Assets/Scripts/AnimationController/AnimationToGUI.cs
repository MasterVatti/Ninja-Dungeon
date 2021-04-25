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
public class AnimationToGUI : MonoBehaviour
{
    [SerializeField]
    private int _countFlyingResourses = 5;
    [SerializeField] 
    private float _delayFlyingResourses = 0.2f;
    [SerializeField]
    private ResourceMiner _resourceMiner;
    [SerializeField]
    private ResourcesView _resourcesView;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = transform as RectTransform;
    }

    private void Start()
    {
        _resourceMiner.PlayerGotResources += TakeResourcesFromBuilding;
    }

    private void TakeResourcesFromBuilding(ResourceType resourceType)
    {
        
        StartCoroutine(MoveResource(resourceType));
        
    }

    private Vector3 GetPositionViewResource(ResourceType resourceType)
    {
        foreach (var resoursce in _resourcesView.ResourceLabels)
        {
            if (resoursce.Type == resourceType)
            {
                return resoursce.Label.rectTransform.position;
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
        _resourceMiner.PlayerGotResources -= TakeResourcesFromBuilding;
    }
}
