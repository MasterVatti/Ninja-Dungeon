using System;
using System.Collections;
using System.Collections.Generic;
using ResourceSystem;
using TMPro;
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

    public TextMeshProUGUI Label
    {
        get => _label;
        set => _label = value;
    }
    
    public float CurrentValue
    {
        get => _currentValue;
        set => _currentValue = value;
    }
    
    public Coroutine CurrentCoroutine
    {
        get => _currentCoroutine;
        set => _currentCoroutine = value;
    }

    [SerializeField]
    private ResourceType _type;
    [SerializeField]
    private TextMeshProUGUI _label;
    private float _currentValue;
    private Coroutine _currentCoroutine;
}
