using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class RicochetShellsBuff : IPassiveBuff
    {
        private int _ricochetsNumber;
        private PlayerCharacteristics _playerCharacteristics;
        
        public RicochetShellsBuff(int ricochetsNumber, PlayerCharacteristics playerCharacteristics)
        {
            _ricochetsNumber = ricochetsNumber;
            
            _playerCharacteristics = playerCharacteristics;
        }
        
        public void StartBuff()
        {
            _playerCharacteristics.RicochetShells += _ricochetsNumber;
        }

        public void StopBuff()
        {
            _playerCharacteristics.RicochetShells -= _ricochetsNumber;
        }
    }
}
