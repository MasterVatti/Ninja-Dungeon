using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class ProjectileCountBuff : IPassiveBuff
    {
        private int _projectileCount;
        private PlayerCharacteristics _playerCharacteristics;
        
        public ProjectileCountBuff(int projectileCount, PlayerCharacteristics playerCharacteristics)
        {
            _projectileCount = projectileCount;
            
            _playerCharacteristics = playerCharacteristics;
        }
        
        public void StartBuff()
        {
            _playerCharacteristics.ProjectileCount += _projectileCount;
        }

        public void StopBuff()
        {
            _playerCharacteristics.ProjectileCount += _projectileCount;
        }
    }
}