using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class RestoreHealthBuff : IBuff
    {
        private readonly float _amountBonusBuff;
        private readonly PersonCharacteristics _personCharacteristics;
    
        public RestoreHealthBuff(int percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _personCharacteristics = personCharacteristics;
            
            _amountBonusBuff = _personCharacteristics.MaxHp * (percentageIncrease / 100f);
        }
    
        public void StartBuff()
        {
            _personCharacteristics.CurrentHp += (int)_amountBonusBuff;
        }
    }
}
