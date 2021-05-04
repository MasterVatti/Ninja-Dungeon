using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class SideShellsBuff : IPassiveBuff
    {
        private PlayerCharacteristics _playerCharacteristics;
        private bool _hasSideShells;
        
        public SideShellsBuff(PlayerCharacteristics playerCharacteristics, bool hasSideShells)
        {
            _playerCharacteristics = playerCharacteristics;
            _hasSideShells = hasSideShells;
        }

        public void StartBuff()
        {
            _playerCharacteristics.SideShells = _hasSideShells;
        }

        public void StopBuff()
        {
            _playerCharacteristics.SideShells = !_hasSideShells;
        }
    }
}
