using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class RicochetShellsBuff : IPassiveBuff
    {
        private int _ricochetsNumber;
        
        public RicochetShellsBuff(int ricochetsNumber)
        {
            _ricochetsNumber = ricochetsNumber;
        }
        
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.RicochetShells += _ricochetsNumber;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.RicochetShells -= _ricochetsNumber;
        }
    }
}
