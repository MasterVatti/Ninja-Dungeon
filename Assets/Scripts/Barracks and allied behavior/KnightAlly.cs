using Characteristics;
using Enemies;
using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает  конкретного союзника Рыцарь и его специальное поведение(ускорение, атака).
    /// </summary>
    public class KnightAlly : MonoBehaviour
    {
        [SerializeField]
        public PersonCharacteristics _personCharacteristics;
        [SerializeField]
        private AlliesAI _alliesAI;
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private int _accelerateSpeed;
        
        [Task]
        private void Attack()
        {
            _alliesAI.Target.GetComponent<HealthBehaviour>().ApplyDamage(_personCharacteristics.AttackDamage);

            _agent.speed = _personCharacteristics.MoveSpeed;
            
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
