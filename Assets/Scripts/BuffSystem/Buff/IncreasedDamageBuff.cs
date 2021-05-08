using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class IncreasedDamageBuff : IPassiveBuff
    {
        private readonly PersonCharacteristics _personCharacteristics;
        private readonly float _amountBonusBuff;
        
        public IncreasedDamageBuff(float percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _personCharacteristics = personCharacteristics;
            
            _amountBonusBuff = _personCharacteristics.AttackDamage * (percentageIncrease / 100);
        }
        
        public void StartBuff()
        { 
            _personCharacteristics.AttackDamage += (int)_amountBonusBuff;
        }

        public void StopBuff()
        {
            _personCharacteristics.AttackDamage -= (int)_amountBonusBuff;
        }
        
    }
}