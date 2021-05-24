using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

/// <summary>
/// Класс отвечает за HUDResource
/// </summary>
public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;
    [SerializeField]
    private float _animationTime;
    
    private List<Resource> _resources;
  
    private void Start()
    {
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
        _resources = MainManager.ResourceManager.GetResources();
        UpdateResourcesAmount();
    }
    
    private void OnResourceAmountChanged(Resource resource, int newAmount)
    {
        var index = _resourceLabels.FindIndex(resourceLabel => resourceLabel.Type == resource.Type);
        _resourceLabels[index].SetAmount(newAmount , _animationTime);
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
                    _resourceLabels[i].СurrentValue = _resources[j].Amount;
                }
            }
        }
    }
}
