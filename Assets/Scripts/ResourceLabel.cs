using System;
using ResourceSystem;
using TMPro;
using UnityEngine;

[Serializable]
public class ResourceLabel 
{
    public ResourceType Type
    {
        get => _type;
        set => _type = value;
    }

    public TextMeshProUGUI Label
    {
        get => _label;
        set => _label = value;
    }

    [SerializeField]
    private ResourceType _type;
    [SerializeField]
    private TextMeshProUGUI _label;
}
