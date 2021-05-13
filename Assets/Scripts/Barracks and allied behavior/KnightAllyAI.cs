using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Cпециальное поведение Рыцаря (Ускорение).
    /// </summary>
    public class KnightAllyAI : MonoBehaviour
    {
        [SerializeField]
        private Unit _unit;
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private int _accelerateSpeed;
        
        [Task]
        private void SlowDown()
        {
            _agent.speed = _unit.Characteristics.MoveSpeed;
            
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
