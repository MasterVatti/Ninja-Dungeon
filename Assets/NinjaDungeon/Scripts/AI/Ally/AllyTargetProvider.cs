using Characteristics;
using Enemies;
using NinjaDungeon.Scripts.ProjectileLauncher;
using ProjectileLauncher;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за определение  Enemy и передачу ее.
    /// </summary>
    public class AllyTargetProvider : MonoBehaviour, ITargetProvider
    {
        [SerializeField]
        private float _aggressionDistance;
        
        private NearestTargetProvider _nearestTargetProvider;
        
        private void Awake()
        {
            _nearestTargetProvider = new NearestTargetProvider();
        }

        public Person GetTarget()
        {
            return _nearestTargetProvider.GetNearestTarget(MainManager.EnemiesManager.Enemies, transform.position, _aggressionDistance);
        }
    }
}