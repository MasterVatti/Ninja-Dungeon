using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class AttackRateBuff : IPassiveBuff
    {
        private readonly PersonCharacteristics _personCharacteristics;
        private readonly float _percentageIncrease;
        private float _amountBonusBuff;

        public AttackRateBuff(float percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _percentageIncrease = percentageIncrease;
            _personCharacteristics = personCharacteristics;
        }
        
        public void StartBuff()
        {
            _amountBonusBuff = _personCharacteristics.AttackRate * (_percentageIncrease / 100);
            _personCharacteristics.AttackRate -= _amountBonusBuff;
        }

        public void StopBuff()
        {
            _personCharacteristics.AttackRate += _amountBonusBuff;
        }
    }
}