using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using ResourceSystem;
using UnityEngine;
/// <summary>
/// Класс отвечает за анимацию передачи ресурсов в указанную точку на Canvas.
/// </summary>
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    
    private float _time = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(moveResource());
        }
    }
    
    private IEnumerator moveResource()
    {
        for (int i = 0; i < 5; i++)
        {
            MainManager.AnimationManager.ShowFlyingResource(ResourceType.Gold, transform.position, _target.position,
                true);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
