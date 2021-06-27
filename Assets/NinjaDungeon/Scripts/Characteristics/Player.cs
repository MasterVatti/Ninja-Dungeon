
using BuffSystem;
using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    {
        public BuffManager BuffManager => _buffManager;

        [SerializeField]
        private BuffManager _buffManager;
    }
}
