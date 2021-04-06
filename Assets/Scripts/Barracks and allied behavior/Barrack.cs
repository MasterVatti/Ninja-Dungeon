using System.Collections.Generic;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    public class Barrack : MonoBehaviour
    {
        public List<GameObject> Allies => _allies;
        
        [SerializeField]
        private List<GameObject> _allies;
    }
}
