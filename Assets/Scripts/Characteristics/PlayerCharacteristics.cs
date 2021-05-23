using UnityEngine;
using UnityEngine.Serialization;

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
        
        public int RicochetProjectiles
        {
            get => _ricochetProjectiles;
            set => _ricochetProjectiles = value;
        }

        public bool FrontalProjectiles
        {
            get => _frontalProjectiles;
            set => _frontalProjectiles = value;
        }
        
        public bool DiagonalProjectiles
        {
            get => _diagonalProjectiles;
            set => _diagonalProjectiles = value;
        }

        public bool ProjectileBack
        {
            get => _projectileBack;
            set => _projectileBack = value;
        }

        public bool SideProjectiles
        {
            get => _sideProjectiles;
            set => _sideProjectiles = value;
        }

        [Header("Weapon")]
        [SerializeField]
        private int _projectileCount = 1;
        [FormerlySerializedAs("ricochetProjectiles")]
        [SerializeField]
        private int _ricochetProjectiles;
        [FormerlySerializedAs("frontalProjectiles")]
        [SerializeField]
        private bool _frontalProjectiles;    
        [FormerlySerializedAs("diagonalProjectiles")]
        [SerializeField]
        private bool _diagonalProjectiles;
        [SerializeField]
        private bool _projectileBack;
        [FormerlySerializedAs("sideProjectiles")]
        [SerializeField]
        private bool _sideProjectiles;
    }
}
