using Characteristics;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using UnityEngine;

namespace NinjaDungeon.Scripts.Characteristics
{
    public class Ally : Person 
    {
        
        public Person CreatedAlly => _ally;
        
        
        [SerializeField]
        private AIAnimationController _animationController;
        
        private Person _ally;
        
        public void SetAlly(Person ally)
        {
            _ally = ally;
            DontDestroyOnLoad(_ally);
        }

        public void TeleportAlly(Vector3 point)
        {
            if (_ally == null)
            {
                return;
            }

            _ally.transform.position = point + Vector3.forward;
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
