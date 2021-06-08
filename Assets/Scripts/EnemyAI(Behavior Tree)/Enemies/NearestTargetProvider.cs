using System.Collections.Generic;
using Characteristics;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Ищет ближайшего врага по отношению к игроку
    /// </summary>
    public class NearestTargetProvider
    {
        
        public T GetNearestTarget<T>(List<T> targets, Vector3 position, float aggressionDistance = float.MaxValue)
            where T : Person
        {
            if (targets.Count == 0)
            {
                return null;
            }
            
            var minDistance = float.MaxValue;
            var minIndex = 0;

            for (var index = 0; index < targets.Count; index++)
            {
                var target = targets[index];
                if (target == null)
                {
                    return null; //TODO:  Убрать эту проверку, понять почему тут выпадает налреференс.
                }
                
                var distanceToTarget = Vector3.Distance(target.transform.position, position);
                
                if (minDistance > distanceToTarget )
                {
                    minDistance = distanceToTarget;
                    minIndex = index;
                }
            }
            
            var distanceToNearestTarget = Vector3.Distance(targets[minIndex].transform.position, position);

            return distanceToNearestTarget <= aggressionDistance ? targets[minIndex] : null;
        }
        
    }
}