using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

public class AnimationController : Singleton<AnimationController>
{
    [SerializeField]
    private float _step;
    [SerializeField]
    private Vector3 _liftingVector;
    [SerializeField]
    private List<ResoursePrefab> _resoursePrefab;
    [SerializeField]
    private AnimationCurve _animationCurve;
    private List<AnimationInformation> _animationInformations;
    private Dictionary<ResourceType, ObjectPool> _resourcePool;
    
    private void Start()
    {
        _animationInformations = new List<AnimationInformation>();
        _resourcePool = new Dictionary<ResourceType, ObjectPool>();
    }
    
    public void ShowFlyingResource(ResourceType resourceType, Vector3 fromWhere, Vector3 where)
    {
        if (_resourcePool.TryGetValue(resourceType, out var objectPool))
        {
            var information = new AnimationInformation
            {
                PrefabResource = objectPool.Get(),
                StartPoint = fromWhere,
                EndPoint = where,
                Progress = 0
            };
            _animationInformations.Add(information);
        }
        else
        {
            objectPool = new ObjectPool(GetResourcePrefab(resourceType), 5);
            _resourcePool.Add(resourceType,objectPool);
            
            var information = new AnimationInformation
            {
                PrefabResource = objectPool.Get(),
                StartPoint = fromWhere,
                EndPoint = where,
                Progress = 0
            };
            _animationInformations.Add(information);
        }
    }

    private void Update()
    {
        for (int i = 0; i < _animationInformations.Count; i++)
        {
            _animationInformations[i].Progress += _step * Time.deltaTime;
            var positionYcurve = _animationCurve.Evaluate(_animationInformations[i].Progress) *
                                  _liftingVector;
            
            _animationInformations[i].PrefabResource.transform.position = Vector3.Lerp
                (_animationInformations[i].StartPoint, _animationInformations[i].EndPoint,
                _animationInformations[i].Progress) + positionYcurve;
            
            if (_animationInformations[i].Progress >= 1)
            {
                _animationInformations[i].PrefabResource.SetActive(false);
                _animationInformations.RemoveAt(i);
            }
        }
    }
    private GameObject GetResourcePrefab(ResourceType resourceType)
    {
        foreach (var resourcePrefab in _resoursePrefab)
        {
            if (resourcePrefab.Type == resourceType)
            {
                return resourcePrefab.Prefab;
            }
        }
        return null;
    }
}