using Characteristics;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using UnityEngine;
using UnityEngine.AI;

namespace NinjaDungeon.Scripts.Characteristics
{
    public class Ally : Person 
    {
        [SerializeField]
        private AIAnimationController _animationController;
        [SerializeField] 
        private NavMeshAgent _agent;

        public void PortingToPlayer()
        {
            _agent.transform.position = MainManager.Player.transform.position - Vector3.forward;
            _agent.updatePosition = false;
            _agent.updatePosition = true;
            //TODO: Тут более изящнее решение нужно найти не нравиться как выглядит.
        }
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        
        private void Start()
        {
            HealthBehaviour.OnDead += _animationController.DeathAnimation;
        }

        private void OnDestroy()
        {
            HealthBehaviour.OnDead -= _animationController.DeathAnimation;
        }
    }
}
