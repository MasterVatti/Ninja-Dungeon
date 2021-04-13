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
    
    private IEnumerator MoveResource(ResourceType resourceType)
    {
        for (int i = 0; i < _countFlyingResourses; i++)
        {
            MainManager.AnimationManager.ShowFlyingResource(resourceType, transform.position, _target.position,
                true);
            yield return new WaitForSeconds(_delayFlyingResourses);
        }
        
    }

    private void OnDestroy()
    {
        _resourceMiner.OnTakeResources -= TakeResourcesFromBuilding;
    }
}
