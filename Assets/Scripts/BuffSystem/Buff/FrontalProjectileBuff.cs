using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.Buff
{
    public class FrontalProjectileBuff : IPassiveBuff
    {
        private int _diagonalProjectileNumber;

        public FrontalProjectileBuff(int diagonalProjectileNumber)
        {
            _diagonalProjectileNumber = diagonalProjectileNumber;
        }
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.FrontalityShells += _diagonalProjectileNumber;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.FrontalityShells -= _diagonalProjectileNumber;
        }
    }
}
