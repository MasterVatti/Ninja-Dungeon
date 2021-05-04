using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class FrontalProjectileBuff : IPassiveBuff
    {
        private PlayerCharacteristics _playerCharacteristics;
        private bool _hasFrontalProjectile;
        
        public FrontalProjectileBuff(PlayerCharacteristics playerCharacteristics, bool hasFrontalProjectile)
        {
            _playerCharacteristics = playerCharacteristics;
            _hasFrontalProjectile = hasFrontalProjectile;
        }
        
        public void StartBuff()
        {
            _playerCharacteristics.FrontalityShells = _hasFrontalProjectile;
        }

        public void StopBuff()
        {
            _playerCharacteristics.FrontalityShells = !_hasFrontalProjectile;
        }
    }    
}
