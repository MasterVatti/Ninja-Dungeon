using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> _pooledObjects = new List<GameObject>();

    public ObjectPool(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateObject(prefab);
        }
    }
    public GameObject Get()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                _pooledObjects[i].SetActive(true);
                return _pooledObjects[i];
            }
        }
        var newObject = CreateObject(_pooledObjects.First());
        newObject.SetActive(true);
        return newObject;
    }
    private GameObject CreateObject(GameObject gameObject)
    {
        var instantiate = Object.Instantiate(gameObject);
        instantiate.name = gameObject.name;
        instantiate.SetActive(false);
        _pooledObjects.Add(instantiate);
        return instantiate;
    }
    public void Release(GameObject gameObject)
    {
        foreach (var variable in _pooledObjects)
        {
            if (gameObject == variable)
            {
                gameObject.SetActive(false);
            }
        }
    }
}