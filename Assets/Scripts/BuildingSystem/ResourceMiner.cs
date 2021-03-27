using System;
using ResourceSystem;
using UnityEngine;
using ResourceManager = Managers.ResourceManager;

/// <summary>
/// Класс возвращает количество ресурса, добытого к данному моменту
/// через свойство CurrentResourceCount.
/// Выдает ресурс игроку, если подойти.
/// </summary>
public class ResourceMiner : MonoBehaviour
{
    //Свойства для UI
    public ResourceType ExtractableResource => _extractableResource;
    public float MaxStorage => _maxStorage;
    public int CurrentResourceCount 
    {
        get
        {
            if (_currentResourceCount < _maxStorage)
            {
                var count = Mathf.FloorToInt((Time.time - _startMiningTime) / _miningPerSecond);
                _currentResourceCount = Mathf.Clamp(count, 0, _maxStorage);
            }

            return _currentResourceCount;
        }
    }

   [SerializeField] 
   private ResourceType _extractableResource;
   [SerializeField] 
   private float _miningPerSecond;
   [SerializeField] 
   private int _maxStorage;
   
   private int _currentResourceCount;
   private float _startMiningTime;

   public void Start()
   {
       _startMiningTime = Time.time;
   }

   private void OnTriggerStay(Collider other)
   {
       if (_currentResourceCount != 0)
       {
           ResourceManager.Instance.AddResource(_extractableResource, _currentResourceCount); 
           _startMiningTime = Time.time;
       }
   }
}
