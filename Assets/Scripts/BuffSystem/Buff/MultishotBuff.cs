using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class MultishotBuff : IPassiveBuff
    {
        private int _multishotsNumber;
        
        public MultishotBuff(int multishotsNumber)
        {
            _multishotsNumber = multishotsNumber;
        }
        
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.MultishotShells += _multishotsNumber;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.MultishotShells += _multishotsNumber;
        }
    }
}