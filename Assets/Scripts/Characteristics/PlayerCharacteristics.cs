using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Класс для характеристик игрока
    /// </summary>
    public class PlayerCharacteristics : PersonCharacteristics
    {
        public int RicochetShells
        {
            get => _ricochetShells;
            set => _ricochetShells = value;
        }
        
        public int MultishotShells
        {
            get => _multishotShells;
            set => _multishotShells = value;
        }
        
        public bool FrontalityShells
        {
            get => _frontalityShells;
            set => _frontalityShells = value;
        }
        
        public int DiagonalShells
        {
            get => _diagonalShells;
            set => _diagonalShells = value;
        }

        [Header("Weapon")]
        [SerializeField]
        private int _ricochetShells;
        [SerializeField]
        private int _multishotShells;
        [SerializeField]
        private bool _frontalityShells;    
        [SerializeField]
        private int _diagonalShells;
    }
}
