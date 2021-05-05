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
    private float _elapsedTime;
    private Coroutine _currentCoroutine;
    private float[] _currentValue;
    private TextMeshProUGUI _lable;

    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();
        InitialValueOfPresentValue();
        
    }
    
    private void OnResourceAmountChanged(Resource resource, float oldAmount , int newAmount, int index)
    {
        var label = GetLabel(resource);
        StopCoroutine();
        if (_currentValue[index] != newAmount)
        {
            _currentCoroutine = StartCoroutine(UpdateResource(label, _currentValue[index], newAmount, index));
            
        }

        label.text = newAmount.ToString();


    }
    
    private IEnumerator UpdateResource(TextMeshProUGUI label, float oldAmount , int newAmount, int index)
    {
        while (_elapsedTime < _animationTime)
        {
            var currentProgress = _elapsedTime / _animationTime;
            _currentValue[index] = Mathf.Lerp(oldAmount, newAmount, currentProgress);
            label.text =  Mathf.Round(_currentValue[index]).ToString(CultureInfo.InvariantCulture);
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

    private void InitialValueOfPresentValue()
    {
        _currentValue = new float[_resources.Count];
        for (int i = 0; i < _resources.Count; i++)
        {
            _currentValue[i] = _resources[i].Amount;
        }
    }
}
