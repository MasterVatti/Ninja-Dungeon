using System.Collections;
using System.Globalization;
using ResourceSystem;
using TMPro;
using UnityEngine;

public class ResourceLabel : MonoBehaviour
{
    public ResourceType Type => _type;
    public TextMeshProUGUI Label => _label;

    public float СurrentValue
    {
        set => _currentValue = value;
    }
    
    [SerializeField]
    private ResourceType _type;
    [SerializeField]
    private TextMeshProUGUI _label;
    private float _currentValue;
    private Coroutine _currentCoroutine;
    private float _elapsedTime;

    public void SetAmount(int newAmount, float animationTime)
    {
        StopCoroutine();
        if (_currentValue != newAmount)
        {
            _currentCoroutine = StartCoroutine(UpdateResource(_currentValue, newAmount, animationTime));
        }
    }
    
    private IEnumerator UpdateResource(float oldAmount , int newAmount, float animationTime)
    {
        while (_elapsedTime < animationTime)
        {
            var currentProgress = _elapsedTime / animationTime;
            _currentValue = Mathf.Lerp(oldAmount, newAmount, currentProgress);
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
