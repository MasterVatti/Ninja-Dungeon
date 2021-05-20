using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Класс отвечает за HUDResource
/// </summary>
public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;
    private List<Resource> _resources;
    [SerializeField]
    private float _animationTime;
    private ResourceType _labelType;


    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();
    }
    
    private void OnResourceAmountChanged(Resource resource, int newAmount)
    {
        var type = FindType(resource);
        var index = _resourceLabels.IndexOf(type);
        _resourceLabels[index].SetAmount(newAmount , _animationTime);
    }
    
    private void OnDestroy()
    {
        MainManager.ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }
    
    private ResourceLabel FindType(Resource resource)
    {
        foreach (var resourceLabel in _resourceLabels)
        {
            if (resourceLabel.Type == resource.Type)
            {
                return resourceLabel;
            }
        }

        throw new ArgumentNullException("Не могу найти текстовое поле " +
                                        " для вывода ресурсов. Проверьте, добавили ли вы его");
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
                    _resourceLabels[i].СurrentValue = _resources[j].Amount;
                }
            }
        }
    }
}
