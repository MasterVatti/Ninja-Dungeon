using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Заготовка синголтона для всех обьектов.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instansce;

    public static T Instance
    {
        get
        {
            if (_instansce == null)
            {
                _instansce = FindObjectOfType<T>();

                if (_instansce == null)
                {
                    var singleton = new GameObject("[SINGLETON]" + typeof(T));
                    _instansce = singleton.AddComponent<T>();
                    DontDestroyOnLoad(_instansce);
                }
            }
            
            return _instansce;
        }
    }
}