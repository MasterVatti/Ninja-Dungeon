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
        private float _arrivaTime = 0.2f;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                GetComponent<Collider>().enabled = false;
                
                StartCoroutine(MoveToPosition());
            }
        }
        
        private IEnumerator MoveToPosition()
        {
            var currentTime = 0f;
            var startPosition = transform.position;
            
            while (currentTime < _arrivaTime)
            {
                var destination = MainManager.PlayerMovementController.transform.position;
                
                transform.position = Vector3.Lerp(startPosition, destination, currentTime / _arrivaTime);
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            Destroy(gameObject);
        }
        
        public virtual void Initialize(ItemLoot itemLoot)
        {
        }
    }
}
