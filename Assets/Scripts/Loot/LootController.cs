using System.Collections.Generic;
using Characteristics;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Loot
{
    /// <summary>
    /// Класс создаёт предметы заданные в объекте с неким шансом
    /// </summary>
    public class LootController : MonoBehaviour
    {
        [SerializeField]
        private float _throwUpForce = 15f;
        [SerializeField]
        private float _recliningForce = 5f;
        [SerializeField]
        private List<EquipmentItem> _equipmentItems = new List<EquipmentItem>(); 
        [SerializeField]
        private List<ResourceItem> _resourceItems = new List<ResourceItem>();

        private HealthBehaviour _enemyHealth;
       
        private void Start()
        {
            _enemyHealth = GetComponent<HealthBehaviour>();
            
            _enemyHealth.OnDead += StartItemCreation;
        }
        
        private void StartItemCreation(PersonCharacteristics enemy)
        {
            CreateItem(_equipmentItems, enemy.transform);
            CreateItem(_resourceItems, enemy.transform);
        }

        private void CreateItem<T>(List<T> listItem, Transform transform) where T : ItemLoot
        {
            foreach (var item in listItem)
            {
                if (GetRandomChance() <= item.DropChance)
                {
                    var itemObject = Instantiate(item.Item, transform.position, Quaternion.identity);
                    
                    InitializeItem(itemObject, item);
                    ScatterObjects(itemObject);
                }
            }
        }
        
        private void ScatterObjects(GameObject item)
        {
            var pushDirection = new Vector3(GetRandomCoordinate(), 0, GetRandomCoordinate());
            
            var rigidBody = item.GetComponent<Rigidbody>();
            
            rigidBody.AddForce((Vector3.up * _throwUpForce) + (pushDirection * _recliningForce), ForceMode.Impulse);
        }

        private void InitializeItem(GameObject gameObject, ItemLoot itemLoot)
        {
            if (gameObject.TryGetComponent(out EquipmentItemLoot item))
            {
               item.Initialize(itemLoot);
            }
        }

        private float GetRandomChance()
        {
            return Random.Range(0f, 100f);
        }

        private float GetRandomCoordinate()
        {
            return Random.Range(-1f, 1f);
        }

        private void OnDestroy()
        {
            _enemyHealth.OnDead -= StartItemCreation;
        }
    }
}
