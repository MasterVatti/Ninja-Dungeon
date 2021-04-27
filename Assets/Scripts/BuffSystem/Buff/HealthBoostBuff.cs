using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class HealthBoostBuff : IBuff
    {
        private int _amountIncreasedHealth;
        
        public HealthBoostBuff(int amountIncreasedHealth)
        {
            _amountIncreasedHealth = amountIncreasedHealth;
        }
        
        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            personCharacteristics.MaxHp += _amountIncreasedHealth;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            personCharacteristics.MaxHp -= _amountIncreasedHealth;
        }
    }
}
