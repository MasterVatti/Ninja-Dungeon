using System.Collections;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

/// <summary>
/// Этот класс позволяет получить иконку для соответствуюшего ресурса
/// </summary>
public class 
    IconsProvider : MonoBehaviour
{
    [SerializeField]
    private List<ResourceImage> _resourceImages = new List<ResourceImage>();
    
    public Sprite GetResourceSprite(ResourceType resourceType)
    {
        foreach (var resource in _resourceImages)
        {
            if (resource.Type == resourceType)
            {
                return resource.Sprite;
            }
        }

        return null;
    }
}
