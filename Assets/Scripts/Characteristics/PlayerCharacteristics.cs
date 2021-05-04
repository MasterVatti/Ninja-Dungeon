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

        public bool ProjectileBack
        {
            get => _projectileBack;
            set => _projectileBack = value;
        }

        public bool SideShells
        {
            get => _sideShells;
            set => _sideShells = value;
        }

        [Header("Weapon")]
        [SerializeField]
        private int _projectileCount = 1;
        [SerializeField]
        private int _ricochetShells;
        [SerializeField]
        private bool _frontalityShells;    
        [SerializeField]
        private bool _diagonalShells;
        [SerializeField]
        private bool _projectileBack;
        [SerializeField]
        private bool _sideShells;
    }
}
