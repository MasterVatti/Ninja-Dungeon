using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class HealthBoostBuff : IPassiveBuff
    {
        private PersonCharacteristics _personCharacteristics;
        private float _amountBonusBuff;
        
        public HealthBoostBuff(float percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _personCharacteristics = personCharacteristics;
            
            _amountBonusBuff = _personCharacteristics.MaxHp * (percentageIncrease / 100);
        }
        
        public void StartBuff()
        {
            _personCharacteristics.MaxHp += (int)_amountBonusBuff;
        }
        
        public void StopBuff()
        {
            _personCharacteristics.MaxHp -= (int)_amountBonusBuff;
        }
        
    }
}
