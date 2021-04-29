using BuffSystem.BuffInterface;
using Characteristics;
using UnityEngine;

namespace BuffSystem.Buff
{
    public class FrontalProjectileBuff : IPassiveBuff
    {
        private bool _hasFrontalProjectiles;

        public FrontalProjectileBuff(bool hasFrontalProjectiles)
        {
            _hasFrontalProjectiles = hasFrontalProjectiles;
        }
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.FrontalityShells = true;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.FrontalityShells = false;
        }
    }    
}
