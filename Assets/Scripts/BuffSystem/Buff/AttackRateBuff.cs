using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class AttackRateBuff : IPassiveBuff
    {
        
        private double _percentageIncrease;
        
        public AttackRateBuff(double percentageIncrease)
        {
            _percentageIncrease = percentageIncrease;
        }
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var percent = _percentageIncrease / 100;

            var attackRateIncreaseQuantity = personCharacteristics.AttackRate * percent;
            
            personCharacteristics.AttackDamage += (int)attackRateIncreaseQuantity;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var percent = _percentageIncrease / 100;

            var attackRateIncreaseQuantity = personCharacteristics.AttackRate * percent;
            
            personCharacteristics.AttackDamage -= (int)attackRateIncreaseQuantity;
        }
    }
}