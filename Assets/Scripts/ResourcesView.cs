using System.Collections.Generic;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private List<ResourceLabel> _resourceLabels;

    private void Update()
    {
        UpdateResourcesAmount();
    }

    private void UpdateResourcesAmount()
    {
        foreach (var resourceLabel in _resourceLabels)
        {
            var resource = MainManager.ResourceManager.GetResourceByType(resourceLabel.Type);
            resourceLabel.Label.text = resource.Amount.ToString();
        }
    }
    
}