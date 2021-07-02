using System.Collections;
using NinjaDungeon.Scripts.BattleManager;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Базовый класс для получения предмета
    /// </summary>
    public class EquipmentItemLoot : MonoBehaviour
    {   
        [SerializeField]
        private float _arrivalTimeMax = 2f; 
        [SerializeField]
        private float _arrivalTimeMin = 0.5f;

        private BattleManager _battleManager;
        private void Start()
        {
            _battleManager = DungeonManager.BattleManager;

            if (_battleManager.HasLevelPassed)
            {
                StartMoveToPosition();
            }
            else
            {
                _battleManager.IsLevelFinished += StartMoveToPosition;
            }
        }

        protected virtual void OnItemPickup()
        {
        }
        
        public virtual void Initialize(ItemLoot itemLoot)
        {
        }
        

        private void StartMoveToPosition()
        {
            GetComponent<Collider>().enabled = false;
                
            StartCoroutine(MoveToPosition());
        }
        
        private IEnumerator MoveToPosition()
        {
            var currentTime = 0f;
            var startPosition = transform.position;
            var arrivalTime = Random.Range(_arrivalTimeMin, _arrivalTimeMax);

            while (currentTime < arrivalTime)
            {
                var destination = MainManager.Player.transform.position;
                
                transform.position = Vector3.Lerp(startPosition, destination, currentTime / arrivalTime);
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            OnItemPickup();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _battleManager.IsLevelFinished -= StartMoveToPosition;
        }
    }
}
