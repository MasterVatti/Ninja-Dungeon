using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

/// <summary>
/// Класс отвечает за анимацию передачи ресурсов.
/// </summary>

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private float _flightTime;
    [SerializeField]
    private List<ResoursePrefab> _resourсePrefab;
    [SerializeField]
    private AnimationCurve _yPositionCurve;
    
    private List<AnimationInformation> _animationInformations;
    private Dictionary<ResourceType, ObjectPool> _resourcePool;
    
    private void Start()
    {
        _animationInformations = new List<AnimationInformation>();
        _resourcePool = new Dictionary<ResourceType, ObjectPool>();
    }
    
    private void Update()
    {
        for (int i = 0; i < _animationInformations.Count; i++)
        {
            var information = _animationInformations[i];
            var positionYcurve = _yPositionCurve.Evaluate(information.Progress) * Vector3.up;
            information.Progress += Time.deltaTime /  _flightTime;
            
            var resourceItem = Vector3.Lerp(information.StartPoint, information.EndPoint, information.Progress)
                               + positionYcurve;
            information.PrefabResource.transform.position = resourceItem;
            
            if (information.Progress >= 1)
            {
                information.PrefabResource.SetActive(false);
                _animationInformations.RemoveAt(i);
                i--;
            }
        }
    }
    
    public void ShowFlyingResource(ResourceType resourceType, Vector3 source, Vector3 destination)
    {
        if (!_resourcePool.TryGetValue(resourceType, out var objectPool))
        {
            objectPool = new ObjectPool(GetResourcePrefab(resourceType));
            _resourcePool.Add(resourceType,objectPool);
        }
        
        var information = new AnimationInformation
        {
            PrefabResource = objectPool.Get(),
            StartPoint = source,
            EndPoint = destination,
            Progress = 0
        };
        _animationInformations.Add(information);
    }
    
    private GameObject GetResourcePrefab(ResourceType resourceType)
    {
        foreach (var resourcePrefab in _resourсePrefab)
        {
            if (resourcePrefab.Type == resourceType)
            {
                return resourcePrefab.Prefab;
            }
        }
        return null;
    }
}