using Characteristics;
using Enemies;
using ProjectileLauncher;
using UnityEngine;


namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за определение  Enemy и передачу ее.
    /// </summary>
    public class AllyTargetProvider : ITargetProvider
    {
        private readonly GameObject _unit;
        private NearestTargetProvider _nearestTargetProvider;
        public AllyTargetProvider(GameObject unit)
        {
            _unit = unit;
        }

        public Person GetTarget()
        {
            return _nearestTargetProvider.GetNearestTarget(MainManager.EnemiesManager.Enemies, _unit.transform.position);
        }
    }
}