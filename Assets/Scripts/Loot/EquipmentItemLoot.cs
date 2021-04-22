using System.Collections;
using Assets.Scripts;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Базовый класс для получения предмета
    /// </summary>
    public class EquipmentItemLoot : MonoBehaviour
    {   
        [SerializeField]
        private float _arrivalTime = 0.2f;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                GetComponent<Collider>().enabled = false;
                
                StartCoroutine(MoveToPosition());
            }
        }
        
        protected virtual void OnItemPickup()
        {
        }
        
        public virtual void Initialize(ItemLoot itemLoot)
        {
        }
        
        private IEnumerator MoveToPosition()
        {
            var currentTime = 0f;
            var startPosition = transform.position;
            
            while (currentTime < _arrivalTime)
            {
                var destination = MainManager.PlayerMovementController.transform.position;
                
                transform.position = Vector3.Lerp(startPosition, destination, currentTime / _arrivalTime);
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            OnItemPickup();
            Destroy(gameObject);
        }
    }
}
