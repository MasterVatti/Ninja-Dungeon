using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class RestoreHealthBuff : IBuff
    {
        private readonly PersonCharacteristics _personCharacteristics;
        private readonly int _percentageIncrease;

        public RestoreHealthBuff(int percentageIncrease, PersonCharacteristics personCharacteristics)
        {
            _percentageIncrease = percentageIncrease;
            _personCharacteristics = personCharacteristics;
        }
    
        public void StartBuff()
        {
            var healAmount = _personCharacteristics.MaxHp * (_percentageIncrease / 100f);
            _personCharacteristics.CurrentHp += (int)healAmount;
        }
    }
}
