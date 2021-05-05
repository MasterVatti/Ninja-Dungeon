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
    private float animationTime;
    private float _elapsedTime;
    private Coroutine _currentCoroutine;
    private int[] _currentValue = new int[3];

    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();
    }
    
    private void OnResourceAmountChanged(Resource resource, int oldAmount , int newAmount, int index )
    {
        StopCoroutine();
        if (_currentValue[index] < oldAmount)
        {
            _currentValue[index] = oldAmount;
        }
        if (_currentValue[index] != newAmount)
        {
            _currentCoroutine = StartCoroutine(UpdateResource(resource, _currentValue[index], newAmount, index));
            
        }

    }
    
    private IEnumerator UpdateResource(Resource resource, int oldAmount , int newAmount, int index)
    {
        var label = GetLabel(resource);
        
        
        while (_elapsedTime < animationTime)
        {
            label.text = Mathf.Round(Mathf.Lerp(oldAmount, newAmount, (_elapsedTime / animationTime))).ToString(CultureInfo.InvariantCulture);
            _currentValue[index] = Convert.ToInt32(label.text);
            _elapsedTime += Time.deltaTime;

            yield return null;
        }
        
        _elapsedTime = 0;
    }
    
    private TextMeshProUGUI GetLabel(Resource resource)
    {
        foreach (var resourceLabel in _resourceLabels)
        {
            if (resourceLabel.Type == resource.Type)
            {
                return resourceLabel.Label;
            }
        }

        throw new ArgumentNullException("Не могу найти текстовое поле " +
                                        " для вывода ресурсов. Проверьте, добавили ли вы его");
    }
    
    private void OnDestroy()
    {
        MainManager.ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
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

    private void StopCoroutine()
    {
        if( _currentCoroutine != null ) 
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }
}
