using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using ResourceSystem;
using UnityEngine;
/// <summary>
/// Класс отвечает за анимацию передачи ресурсов в указанную точку на Canvas.
/// </summary>
public class AmimationToGUI : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    
    [SerializeField]
    private int _countFlyingResourses = 5;

    [SerializeField] 
    private float _delayFlyingResourses = 0.2f;
    
    private float _time = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveResource());
        }
    }
    
    private IEnumerator MoveResource()
    {
        for (int i = 0; i < _countFlyingResourses; i++)
        {
            MainManager.AnimationManager.ShowFlyingResource(ResourceType.Gold, transform.position, _target.position,
                true);
            yield return new WaitForSeconds(_delayFlyingResourses);
        }
        
    }
}
