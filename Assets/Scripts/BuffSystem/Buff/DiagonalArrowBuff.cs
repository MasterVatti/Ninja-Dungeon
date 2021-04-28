using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class DiagonalArrowBuff : IPassiveBuff
    {
        private int _diagonalArrowsNumber;

        public DiagonalArrowBuff(int diagonalArrowsNumber)
        {
            _diagonalArrowsNumber = diagonalArrowsNumber;
        }

        public void StartBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.DiagonalShells += _diagonalArrowsNumber;
        }

        public void StopBuff(PersonCharacteristics personCharacteristics)
        {
            var playerCharacteristics = personCharacteristics.GetComponentInChildren<PlayerCharacteristics>();

            playerCharacteristics.DiagonalShells -= _diagonalArrowsNumber;
        }
    }
}
