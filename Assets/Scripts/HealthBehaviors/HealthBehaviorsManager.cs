using System.Collections.Generic;
using UnityEngine;

namespace HealthBehaviors
{
    /// <summary>
    /// отвечает за все HealthBehavior
    /// </summary>
    public class HealthBehaviorsManager : MonoBehaviour
    {
        public List<HealthBehavior> HealthBehaviors => _healthBehaviors;

        public List<HealthBehavior> _healthBehaviors = new List<HealthBehavior>();

        public void AddToHealthBehaviors(HealthBehavior healthBehavior)
        {
            _healthBehaviors.Add(healthBehavior);
        }
        
        public void RemoveFromHealthBehaviors(HealthBehavior healthBehavior)
        {
            _healthBehaviors.Add(healthBehavior);
        }
    }
}