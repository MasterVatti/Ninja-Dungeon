using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class RestoreHealthBuff : IBuff
    {
        private int _amountHealthRestored;
        private PersonCharacteristics _personCharacteristics;
    
        public RestoreHealthBuff(int amountHealthRestored, PersonCharacteristics personCharacteristics)
        {
            _amountHealthRestored = amountHealthRestored;
        
            _personCharacteristics = personCharacteristics;
        }
    
        public void StartBuff()
        {
            _personCharacteristics.CurrentHp += _amountHealthRestored;
        }
    }
}
