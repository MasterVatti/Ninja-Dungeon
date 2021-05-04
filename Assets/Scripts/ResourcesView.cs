using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ResourceSystem;
using TMPro;
using UnityEngine;
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
    private float elapsedTime;
    private Coroutine currentCoroutine;

    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();
    }
    

    private void OnResourceAmountChanged(Resource resource, int oldAmount , int newAmount )
    {
        if (Mathf.Round(oldAmount - newAmount) == 1 )
        {
            StopCoroutine();
        }
        currentCoroutine = StartCoroutine(UpdateResource(resource, oldAmount, newAmount));
    }
    
    private IEnumerator UpdateResource(Resource resource, int oldAmount , int newAmount)
    {
        var label = GetLabel(resource);
        
        while (elapsedTime < animationTime)
        {
            label.text = Mathf.Round(Mathf.Lerp(oldAmount, newAmount, (elapsedTime / animationTime))).ToString(CultureInfo.InvariantCulture);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        
        elapsedTime = 0;
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
        if( currentCoroutine != null ) 
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }
}
