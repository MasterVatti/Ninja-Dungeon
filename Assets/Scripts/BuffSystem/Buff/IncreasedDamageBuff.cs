using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class IncreasedDamageBuff : IPassiveBuff
    {
        private double _percentageIncrease;
        
        public IncreasedDamageBuff(double percentageIncrease)
        {
            _percentageIncrease = percentageIncrease;
        }
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var percent = _percentageIncrease / 100;

            var damageIncreaseAmount = personCharacteristics.AttackDamage * percent;
            
            personCharacteristics.AttackDamage += (int)damageIncreaseAmount;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var percent = _percentageIncrease / 100;

            var damageIncreaseAmount = personCharacteristics.AttackDamage * percent;
            
            personCharacteristics.AttackDamage -= (int)damageIncreaseAmount;
        }
        
    }
}
