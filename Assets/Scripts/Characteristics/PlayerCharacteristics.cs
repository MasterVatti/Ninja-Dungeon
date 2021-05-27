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
        
        public int FrontalityShells
        {
            get => _frontalityShells;
            set => _frontalityShells = value;
        }
        
        public bool DiagonalShells
        {
            get => _diagonalShells;
            set => _diagonalShells = value;
        }
        
        public int LevelUpperWorld
        {
            get => LevelUpperWorld;
            set => Mathf.Clamp(value,1,_levelMaxUpperWorld);
        }
        
        public int LevelDungeon
        {
            get => _levelDungeon;
            set => Mathf.Clamp(value, 1, _levelMaxDungeon);
        }
        
        public int ExperienceUpperWorld { get; set; }
        
        public int ExperienceDungeon { get; set; }

        [Header("Weapon")]
        [SerializeField]
        private int _ricochetShells;
        [SerializeField]
        private int _multishotShells;
        [SerializeField]
        private int _frontalityShells;    
        [SerializeField]
        private bool _diagonalShells;
        
        [Header("Level")]
        [SerializeField]
        private int _levelMaxUpperWorld;
        [SerializeField]
        private int _levelMaxDungeon;

        private int _levelDungeon;
        private int _levelUpperWorld;

    }
}
