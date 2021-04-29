using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class HealthBoostBuff : IPassiveBuff
    {
        private double _percentageIncrease;
        
        public HealthBoostBuff(double percentageIncrease)
        {
            _percentageIncrease = percentageIncrease;
        }
        
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var percent = _percentageIncrease / 100;

            var amountIncreasedHealth = personCharacteristics.MaxHp * percent;
            
            personCharacteristics.MaxHp += (int)amountIncreasedHealth;
        }
        
        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var percent = _percentageIncrease / 100;

            var amountIncreasedHealth = personCharacteristics.MaxHp * percent;
            
            personCharacteristics.MaxHp -= (int)amountIncreasedHealth;
        }
        
    }
}