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
    //Свойства для UI
    public ResourceType ExtractableResource => _miningResource;
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
   private ResourceType _miningResource;
   [SerializeField] 
   private float _miningPerSecond;
   [SerializeField] 
   private int _maxStorage;
   [SerializeField] 
   private float _resourceDeliverySpeedPerSecond=3;
   
   private int _currentResourceCount;
   private float _startMiningTime;

   public void Start()
   {
       _startMiningTime = Time.time;
   }

   private void OnTriggerStay(Collider other)
   {
       
       //пытался реализовать метод, который с определенной скоростью
       //будет доставлять ресурсы из майнера в ресурсы персонажа.
       //Удалось сделать так, чтобы ресурсы у хринилища постепенно уменьшались.
       //И все вроде бы хорошо, но если ресурсов в майнере станет 0, то он сходит с ума
       //и начинает прибавлять ресурсы игроку очень-очень быстро
       var s = CurrentResourceCount;
       if (s != 0) 
       { 
           _startMiningTime = Mathf.Clamp(_startMiningTime + Time.deltaTime * _resourceDeliverySpeedPerSecond, 0, Time
                 .time);

           MainManager.ResourceManager.AddResource(_miningResource, s - CurrentResourceCount);
       }
   }
}
