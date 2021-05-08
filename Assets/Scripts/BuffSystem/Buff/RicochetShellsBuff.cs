using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class RicochetShellsBuff : IPassiveBuff
    {
        private readonly int _ricochetsNumber;
        private readonly PlayerCharacteristics _playerCharacteristics;
        
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
