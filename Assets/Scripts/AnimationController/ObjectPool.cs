using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс создаёт пулл объектов, которые нам понадобятся в любой момент
/// вызовом методо Get
/// </summary>
public class ObjectPool
{
    private List<GameObject> _pooledObjects = new List<GameObject>();
    
    private GameObject _poolObject;
    private float _amount;

    public ObjectPool(GameObject poolObject, int amount = 5)
    {
        _poolObject = poolObject;
        _amount = amount;

        PoolCreator();
        
        SceneManager.sceneLoaded += CreateAfterLoadScene;
    }
    
    private void CreateAfterLoadScene(Scene scene, LoadSceneMode mode)
    {
        ClearPool();
        PoolCreator();
    }

    private void PoolCreator()
    {
        for (int i = 0; i < _amount; i++)
        {
            CreateObject(_poolObject);
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

    public void ClearPool()
    {
        foreach (var pooledObject in _pooledObjects)
        {
            Object.Destroy(pooledObject);
        }
        
        _pooledObjects.Clear();
    }
}