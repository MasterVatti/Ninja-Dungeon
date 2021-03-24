using ResourceSystem;
using System;
using UnityEngine;

/// <summary>
/// Класс содержит информацию о ресурсе и соответствующий ему префаб
/// </summary>

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