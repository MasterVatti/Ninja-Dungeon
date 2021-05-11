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
    private TextMeshProUGUI _lable;
    private ResourceLabel _resourceLabelCar;
    private float _elapsedTime;

    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();

    }
    
    private void OnResourceAmountChanged(Resource resource, float oldAmount , int newAmount, int index)
    {
        var lable = GetLabel(resource);
        StopCoroutine(index);
        var currentValue = _resourceLabels[index].CurrentValue;
        if (currentValue != newAmount)
        {
          _resourceLabels[index].CurrentCoroutine = StartCoroutine(UpdateResource(lable,currentValue, newAmount,  index));
            
        }
        
    }
    
    private IEnumerator UpdateResource(TextMeshProUGUI label, float oldAmount , int newAmount, int index)
    {
        while (_elapsedTime < _animationTime)
        {
            var currentProgress = _elapsedTime / _animationTime;
            _resourceLabels[index].CurrentValue= Mathf.Lerp(oldAmount, newAmount, currentProgress);
            label.text =  Mathf.Round(_resourceLabels[index].CurrentValue).ToString(CultureInfo.InvariantCulture);
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
                    _resourceLabels[i].CurrentValue = _resources[j].Amount;
                }
            }
        }
    }
    
    private void StopCoroutine(int index)
        {
            if( _resourceLabels[index].CurrentCoroutine != null ) 
            {
                StopCoroutine(_resourceLabels[index].CurrentCoroutine);
                _resourceLabels[index].CurrentCoroutine = null;
            }
        }
    
}
