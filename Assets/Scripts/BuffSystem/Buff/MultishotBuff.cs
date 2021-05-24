using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class ProjectileCountBuff : IPassiveBuff
    {
        private readonly int _projectileCount;
        private readonly PlayerCharacteristics _playerCharacteristics;
        
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