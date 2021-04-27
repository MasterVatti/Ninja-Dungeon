using UnityEngine;

namespace Characteristics
{
    public class Enemy : Person
    {
        public EnemyCharacteristics EnemyCharacteristics => _enemyCharacteristics;

        [SerializeField]
        private EnemyCharacteristics _enemyCharacteristics;
    }
}
