using System;
using ResourceSystem;
using UnityEngine;

[Serializable]
public class ResourceImage
{
    public ResourceType Type
    {
        get => _type;
        set => _type = value;
    }

    public Sprite Sprite
    {
        get => _resourceSprite;
        set => _resourceSprite = value;
    }

    [SerializeField]
    private ResourceType _type;

    [SerializeField]
    private Sprite _resourceSprite;
}