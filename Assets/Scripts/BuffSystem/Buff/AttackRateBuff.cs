using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class AttackRateBuff : IPassiveBuff
    {
        private readonly PersonCharacteristics _personCharacteristics;
        private readonly float _amountBonusBuff;
        
        public AttackRateBuff(float percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _personCharacteristics = personCharacteristics;
            
            _amountBonusBuff = _personCharacteristics.AttackRate * (percentageIncrease / 100);
        }
        
        public void StartBuff()
        {
            _personCharacteristics.AttackRate -= _amountBonusBuff;
        }

        public void StopBuff()
        {
            _personCharacteristics.AttackRate += _amountBonusBuff;
        }
    }
}