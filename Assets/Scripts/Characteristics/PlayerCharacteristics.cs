using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Класс для характеристик игрока
    /// </summary>
    public class PlayerCharacteristics : PersonCharacteristics
    {
        public int ProjectileCount
        {
            get => _projectileCount;
            set => _projectileCount = value;
        }
        
        public int RicochetShells
        {
            get => _ricochetShells;
            set => _ricochetShells = value;
        }

        public bool FrontalityShells
        {
            get => _frontalityShells;
            set => _frontalityShells = value;
        }
        
        public bool DiagonalShells
        {
            get => _diagonalShells;
            set => _diagonalShells = value;
        }

        [Header("Weapon")]
        [SerializeField]
        private int _projectileCount;
        [SerializeField]
        private int _ricochetShells;
        [SerializeField]
        private bool _frontalityShells;    
        [SerializeField]
        private bool _diagonalShells;
    }
}
