using System;
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
        
        public int LevelUpperWorld
        {
            get => _levelUpperWorld;
            set => _levelUpperWorld = Mathf.Clamp(value, 0, _levelMaxUpperWorld);
        }

        public int LevelDungeon
        {
            get => _levelDungeon;
            set => _levelDungeon = Mathf.Clamp(value, 0, _levelMaxDungeon);
        }

        public int MaximumExperienceLevelDungeon
        {
            get => _maximumExperienceLevelDungeon;
            set => _maximumExperienceLevelDungeon = value;
        }

        public int MaximumExperienceLevelUpperWorld
        {
            get => _maximumExperienceLevelUpperWorld;
            set => _maximumExperienceLevelUpperWorld = value;
        }
        
        public int ExperienceUpperWorld { get; set; }
        public int ExperienceDungeon { get; set; }
        public int LevelMaxDungeon => _levelMaxDungeon;
        public int LevelMaxUpperWorld => _levelMaxUpperWorld;

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
        
        [Header("Level")]
        [SerializeField]
        private int _levelMaxUpperWorld;
        [SerializeField]
        private int _levelMaxDungeon;
        [SerializeField]
        private int _maximumExperienceLevelUpperWorld;
        [SerializeField]
        private int _maximumExperienceLevelDungeon;
        
        private int _levelDungeon;
        private int _levelUpperWorld;
    }
}
