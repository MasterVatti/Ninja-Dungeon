using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ResourceSystem;
using TMPro;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;
    
    private List<Resource> _resources;

    private float _time = 0.2f;
    
    private int _count = 10;


    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();
    }
    
    /// <summary>
    /// Добавлено для теста. При нажатии на спейс дает 100 дерева
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            MainManager.ResourceManager.AddResource(ResourceType.Lumber, 100);
        }
    }
    
    private void OnResourceAmountChanged(Resource resource, int amount)
    {
        StartCoroutine(UpdateResource(resource, amount));
    }

    private IEnumerator UpdateResource(Resource resource, int amount)
    {
        var exitCondition = resource.Amount + amount;
        var sign = GetOperationSign(amount);
        var label = GetLabel(resource);
        
        while (int.Parse(label.text) != exitCondition)
        {
            var currentAmount = float.Parse(label.text);
            var newAmount = currentAmount + (_count * sign);
            label.text = newAmount.ToString(CultureInfo.InvariantCulture);
            yield return new WaitForSeconds(_time);
        }
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

    private int GetOperationSign(float amount)
    {
        if (amount < 0)
        {
            return -1;
        }
        
        return 1;
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
