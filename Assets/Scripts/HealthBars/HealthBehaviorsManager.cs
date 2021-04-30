using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace HealthBars
{
    public class HealthBehaviorsManager : MonoBehaviour
    {
        public List<HealthBehavior> HealthBehaviors => _healthBehaviors;

        public List<HealthBehavior> _healthBehaviors = new List<HealthBehavior>();
    }
}
