using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class ProjectileBackBuff : IPassiveBuff
    {
        private PlayerCharacteristics _playerCharacteristics;
        private bool _hasProjectileBack;
        
        public ProjectileBackBuff(PlayerCharacteristics playerCharacteristics, bool hasProjectileBack)
        {
            _playerCharacteristics = playerCharacteristics;
            _hasProjectileBack = hasProjectileBack;
        }

        public void StartBuff()
        {
            _playerCharacteristics.ProjectileBack = _hasProjectileBack;
        }

        public void StopBuff()
        {
            _playerCharacteristics.ProjectileBack = !_hasProjectileBack;
        }
    }
}
