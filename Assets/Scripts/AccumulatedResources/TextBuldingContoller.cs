using System;
using UnityEngine;

public class TestBuldingContoller : MonoBehaviour
{
    public event Action NewBuiltBuilding;

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
            MainManager.BuildingManager.ConstructedBuldings.Add(qwe);
            NewBuiltBuilding?.Invoke();
        }
    }
}
