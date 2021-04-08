using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetMaximalHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SetHealthBarValue(int health)
    {
        _slider.value = health;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
