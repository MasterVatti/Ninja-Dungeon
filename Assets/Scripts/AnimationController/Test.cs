using System;
using System.Collections;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AnimationController.Instance.ShowFlyingResource(ResourceType.Gold,other.transform.position,transform.position);
    }
}
