using System.Collections;
using Assets.Scripts.BattleManager;
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
        private float _arrivalTime = 1f;

        private BattleManager _battleManager;
        private void Start()
        {
            _battleManager = MainManager.BattleManager;

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

        private void OnDestroy()
        {
            _battleManager.IsLevelFinished -= StartMoveToPosition;
        }
    }
}
