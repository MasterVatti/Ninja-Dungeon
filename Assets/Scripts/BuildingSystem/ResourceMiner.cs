using ResourceSystem;
using UnityEngine;
using ResourceManager = Managers.ResourceManager;

/// <summary>
/// Класс добавляется к зданию и добывает определенный ресурс.
/// Выдает ресурс игроку, если подойти
/// </summary>
public class ResourceMiner : MonoBehaviour
{
    private const int MINING_PER_TICK=1;
    
   [SerializeField] 
   private ResourceType _extractableResource;
   [SerializeField] 
   private float _miningTime;
   [SerializeField] 
   private int _maxStorage;
   
   
   private int _currentResource;
   private float _currentCooldown;

   //Свойства для UI
   public ResourceType ExtractableResource => _extractableResource;
   public float MAXStorage => _maxStorage;
   public float CurrentResource => _currentResource;


   private void Update()
   {
     MiningResource();
   }

   private void OnTriggerStay(Collider other)
   {
       if (_currentResource != 0)
       {
           ResourceManager.Instance.AddResource(_extractableResource, _currentResource);
           _currentResource = 0;
       }
   }

   private void MiningResource()
   {
       if (IsMiningTime() && IsStorageAvailable())
       {
           _currentResource += MINING_PER_TICK;
       }
   }

   private bool IsStorageAvailable()
   {
       if (_currentResource < _maxStorage)
       {
           return true;
       }

       return false;
   }

   private bool IsMiningTime()
   {
       if (Time.time > _currentCooldown)
       {
           _currentCooldown = Time.time + _miningTime;
           return true;
       }

       return false;
   }

}
