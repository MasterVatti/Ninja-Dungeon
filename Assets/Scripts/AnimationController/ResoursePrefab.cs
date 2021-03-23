using ResourceSystem;
using System;
using UnityEngine;

[Serializable]
public class ResoursePrefab
{
    public ResourceType Type
    {
        get => _type;
        set => _type = value;
    }

    public GameObject Prefab
    {
        get => _resoursePrefab;
        set => _resoursePrefab = value;
    }

    [SerializeField]
    private ResourceType _type;

    [SerializeField]
    private GameObject _resoursePrefab;
}