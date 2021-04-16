using System;
using System.Collections;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ResourceLabel 
{
    public ResourceType Type
    {
        get => _type;
        set => _type = value;
    }

    public Text Label
    {
        get => _label;
        set => _label = value;
    }

    [SerializeField]
    private ResourceType _type;
    [SerializeField]
    private Text _label;
}
