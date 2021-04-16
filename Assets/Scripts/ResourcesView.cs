using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;
    
    private List<Resource> _resources;


    void Start()
    {
        _resources = MainManager.ResourceManager.GetResources();
    }

    void Update()
    {
        UpdateResourcesAmount();
    }

    private void UpdateResourcesAmount()
    {
        for (int i = 0; i < _resourceLabels.Count; i++)
        {
            for (int j = 0; j < _resources.Count; j++)
            {
                if (_resourceLabels[i].Type == _resources[j].Type )
                {
                    _resourceLabels[i].Label.text = _resources[j].Amount.ToString();
                    break;
                }
            }
        }
    }
    
}
