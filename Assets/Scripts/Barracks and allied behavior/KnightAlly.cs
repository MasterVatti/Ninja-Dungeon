using Characteristics;
using Enemies;
using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает  конкретного союзника Рыцарь и его специальное поведение.
    /// </summary>
    public class KnightAlly : PersonCharacteristics
    {
        [SerializeField]
        private AlliesAI _alliesAI;
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private int _accelerateSpeed;
        
        [Task]
        private void Attack()
        {
            _alliesAI.Target.GetComponent<HealthBehaviour>().ApplyDamage(AttackDamage);

            _agent.speed = MoveSpeed;
            
            Task.current.Succeed();
        }
        [Task]
        private void WillAccelerate()
        {
            _agent.speed = _accelerateSpeed;
            
            Task.current.Succeed();
        }
        
    }
}
