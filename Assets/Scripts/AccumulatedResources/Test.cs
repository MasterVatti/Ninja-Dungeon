using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public event Action <GameObject> OnBuildFinished;

    [SerializeField]
    private GameObject qwe;

    void Awake()
    {
        MainManager.BuildingManager.ConstructedBuldings.Add(qwe);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            var eqw = Instantiate(qwe,transform.position,Quaternion.identity);
            MainManager.BuildingManager.ConstructedBuldings.Add(eqw);
            OnBuildFinished?.Invoke(eqw);
        }
    }
}

