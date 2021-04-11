using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesView : MonoBehaviour
{

    private List<Resource> _resources;
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;


    void Start()
    {
        _resources = MainManager.ResourceManager.GetResources();
    }

    void Update()
    {
        ResourceMapping();

    }

    private void ResourceMapping()
    {
        for (int i = 0; i < _resources.Count; i++)
        {
            for (int j = 0; j < _resources.Count; j++)
            {
                if (_resources[i].Type == _resourceLabels[j].Type)
                {
                    _resourceLabels[j].Label.text = _resources[i].Amount.ToString();
                }
            }
        }
    }
    
}
