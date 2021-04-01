using System;
using ResourceSystem;
using UnityEngine;
using ResourceManager = Managers.ResourceManager;

/// <summary>
/// Класс возвращает количество ресурса, добытого к данному моменту
/// через свойство CurrentResourceCount.
/// Выдает ресурс игроку, если подойти.
/// </summary>
public class ResourceMiner : Building
{
    private int DELIVER_RESOURCE_COUNT = 1;
    
    //Свойства для UI
    public ResourceType ExtractableResource => _miningResource;
    public float MaxStorage => _maxStorage;
    public int CurrentResourceCount 
    {
        get
        {
            if (_currentResourceCount < _maxStorage)
            {
                var count = Mathf.FloorToInt((Time.time - _startMiningTime) * _miningPerSecond);
                _currentResourceCount = Mathf.Clamp(count, 0, _maxStorage);
            }

            return _currentResourceCount;
        }
    }

   [SerializeField] 
   private ResourceType _miningResource;
   [SerializeField] 
   private float _miningPerSecond;
   [SerializeField] 
   private int _maxStorage;
   [SerializeField] 
   private float _resourceDeliverySpeedPerSecond=1;
   
   private int _currentResourceCount;
   private float _startMiningTime;
   private float _currenCooldown;

   public void Start()
   {
       _startMiningTime = Time.time;
   }

   private void OnTriggerStay(Collider other)
   {
       if (CurrentResourceCount != 0 && IsDeliveryTime())
       {
           _startMiningTime = _startMiningTime + DELIVER_RESOURCE_COUNT/_miningPerSecond;
           MainManager.ResourceManager.AddResource(_miningResource, DELIVER_RESOURCE_COUNT);
       }
   }

   private bool IsDeliveryTime()
   {
       if (Time.time > _currenCooldown)
       {
           _currenCooldown = Time.time + DELIVER_RESOURCE_COUNT / _resourceDeliverySpeedPerSecond;
           return true;
       }

       return false;    
   }
}
