using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Loot
{
    public class LootController : MonoBehaviour
    {
        [SerializeField]
        private float _throwUpForce = 15f;
        [SerializeField]
        private float _recliningForce = 5f;
        [SerializeField]
        private List<ItemInformation> _itemInformations = new List<ItemInformation>();

        private EnemyHealth _enemyHealth;
       
        private void Start()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            
            _enemyHealth.EnemyDie += StartItemCreation;
        }
        
        private void StartItemCreation(Enemies.Enemy enemy)
        {
            foreach (var item in _itemInformations)
            {
                if (RandomChance() <= item.DropChance)
                {
                    var buildingView = Instantiate(item.Item, enemy.transform.position, Quaternion.identity);
                    ScatterObjects(buildingView);
                }
            }
        }
        
        private void ScatterObjects(GameObject item)
        {
            var pushDirection = new Vector3(RandomCoordinate(), 0, RandomCoordinate());
            
            var rigidBody = item.GetComponent<Rigidbody>();
            
            rigidBody.AddForce((Vector3.up * _throwUpForce) + (pushDirection * _recliningForce), ForceMode.Impulse);
        }

        private float RandomChance()
        {
            return Random.Range(0f, 100f);
        }

        private float RandomCoordinate()
        {
            return Random.Range(-1f, 1f);
        }

        private void OnDestroy()
        {
            _enemyHealth.EnemyDie -= StartItemCreation;
        }
    }
}
