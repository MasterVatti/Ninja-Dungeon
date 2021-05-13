using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за определение  Enemy и передачу ее.
    /// </summary>
    public class AllyTargetProvider : MonoBehaviour, ITargetProvider
    {
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private float _aggressionDistance;
        
        private GameObject _target;
        
        public GameObject ProvideTarget()
        {
            return _target;
        }
        
        private bool IsAtRequiredDistance(Person enemy)
        {
            var targetDistance = Vector3.Distance(enemy.transform.position, _agent.transform.position);
            return targetDistance <= _aggressionDistance;
        }

        [Task]
        private bool IsEnemyInSight()
        {
            if (MainManager.EnemiesManager.Enemies.Count != 0)
            {
                foreach (var enemy in MainManager.EnemiesManager.Enemies)
                {
                    if (enemy != null && IsAtRequiredDistance(enemy))
                    {
                        _target = enemy.gameObject;
                        return true;
                    }
                }

                return false;
            }
            
            return false;
        }
        
        [Task]
        private bool IsTargetKilled()
        {
            return _target == null;
        }
    }
}