using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ResourceLabel : MonoBehaviour
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
    private float _currentValue;
    private Coroutine _currentCoroutine;
    private float _elapsedTime;

    private void Start()
    {
        _currentValue = Convert.ToSingle(Label.text);
    }

    public void SetAmount(int newAmount, float animationTime)
    {
        StopCoroutine();
        if (_currentValue != newAmount)
        {
            _currentCoroutine = StartCoroutine(UpdateResource(_currentValue, newAmount, animationTime));
            
        }
        
    }
    
    private IEnumerator UpdateResource( float oldAmount , int newAmount, float animationTime)
    {
        while (_elapsedTime < animationTime)
        {
            var currentProgress = _elapsedTime / animationTime;
            _currentValue= Mathf.Lerp(oldAmount, newAmount, currentProgress);
            Label.text =  Mathf.Round(_currentValue).ToString(CultureInfo.InvariantCulture);
            _elapsedTime += Time.deltaTime;

            yield return null;
        }
        _elapsedTime = 0;
    }

    private void StopCoroutine()
    {
        if (_currentCoroutine != null) 
        {
            StopCoroutine(_currentCoroutine); 
            _currentCoroutine = null;
        }
    }
    
}
