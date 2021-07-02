
using BuffSystem;
using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    {
        public BuffManager BuffManager => _buffManager;
        public Person Ally => _ally;

        [SerializeField]
        private BuffManager _buffManager;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private Person _ally;

        public void SetAlly(Person ally)
        {
            _ally = ally;
            DontDestroyOnLoad(_ally);
        }

        public void TeleportAlly()
        {
            if (_ally == null)
            {
                return;
            }

            _ally.transform.position = transform.position + Vector3.forward;
        }
        
    }
}
