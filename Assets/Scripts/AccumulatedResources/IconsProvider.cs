using System.Collections.Generic;
using Characteristics;
using ResourceSystem;
using UnityEngine;

/// <summary>
/// Этот класс позволяет получить иконку для соответствуюшего ресурса
/// </summary>
public class IconsProvider : MonoBehaviour
{
    [SerializeField]
    private List<ResourceImage> _resourceImages = new List<ResourceImage>();
    [SerializeField]
    private List<CharacteristicImage> _characteristicImages = new List<CharacteristicImage>();
    
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

    public Sprite GetCharacteristicImage(CharacteristicType type)
    {
        foreach (var characteristicImage in _characteristicImages)
        {
            if (characteristicImage.Type == type)
            {
                return characteristicImage.Sprite;
            }
        }

        return null;
    }
}
