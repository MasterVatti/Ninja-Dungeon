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
        get => _resourseSprite;
        set => _resourseSprite = value;
    }

    [SerializeField]
    private ResourceType _type;

    [SerializeField]
    private Sprite _resourseSprite;
}