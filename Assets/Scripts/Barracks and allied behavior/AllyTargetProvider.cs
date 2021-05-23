using Characteristics;
using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    public class AITargetProvider : MonoBehaviour, ITargetProvider
    {
        [SerializeField]
        private ITargetProvider _targetProvider;

        private Person _target;

        public bool UpdateTarget()
        {
            var oldTarget = _target;
            _target = _targetProvider.GetTarget();
            return _target != null && _target != oldTarget;
        }

        public bool ShouldChangeTarget(Person person)
        {
            return person == null;
        }

        public Person GetTarget()
        {
            return _target;
        }
    }


    public class AIBehaviour : MonoBehaviour
    {
        [SerializeField]
        private AITargetProvider _aiTargetProvider;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;

        [Task]
        private bool SelectNewTarget()
        {
            return _aiTargetProvider.UpdateTarget();
        }

        [Task]
        private bool Chase()
        {
            // TODO:
            return true;
        }

        [Task]
        private bool IsEnemyInSight()
        {
            // TODO:
            return _aiTargetProvider.GetTarget() == null;
        }

        [Task]
        private bool IsTargetKilled()
        {
            return _aiTargetProvider.GetTarget() == null;
        }
    }
    
    
    /// <summary>
    /// Отвечает за определение  Enemy и передачу ее.
    /// </summary>
    public class AllyTargetProvider : MonoBehaviour, ITargetProvider
    {
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private float _aggressionDistance;
        
        private Person _target;
        
        public Person GetTarget()
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
                        _target = enemy.gameObject.GetComponent<Person>();
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