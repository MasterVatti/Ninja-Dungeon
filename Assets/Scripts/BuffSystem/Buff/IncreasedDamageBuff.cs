using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class IncreasedDamageBuff : IPassiveBuff
    {
        private readonly PersonCharacteristics _personCharacteristics;
        private readonly float _percentageIncrease;
        private float _amountBonusBuff;

        public IncreasedDamageBuff(float percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _percentageIncrease = percentageIncrease;
            _personCharacteristics = personCharacteristics;
        }
        
        public void StartBuff()
        { 
            _amountBonusBuff = _personCharacteristics.AttackDamage * (_percentageIncrease / 100f);
            _personCharacteristics.AttackDamage += (int)_amountBonusBuff;
        }

        public void StopBuff()
        {
            _personCharacteristics.AttackDamage -= (int)_amountBonusBuff;
        }
        
    }
}