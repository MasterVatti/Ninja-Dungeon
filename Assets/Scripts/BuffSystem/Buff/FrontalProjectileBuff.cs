using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class FrontalProjectileBuff : IPassiveBuff
    {
        private PlayerCharacteristics _playerCharacteristics;
        private bool _hasFrontalProjectile;
        
        public FrontalProjectileBuff(PlayerCharacteristics playerCharacteristics)
        {
            _playerCharacteristics = playerCharacteristics;
        }
        
        public void StartBuff()
        {
            _playerCharacteristics.FrontalityShells = true;
        }

        public void StopBuff()
        {
            _playerCharacteristics.FrontalityShells = false;
        }
    }    
}
