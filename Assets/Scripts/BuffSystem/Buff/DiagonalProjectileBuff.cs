using BuffSystem.BuffInterface;
using Characteristics;

namespace BuffSystem.Buff
{
    public class DiagonalProjectileBuff : IPassiveBuff
    {
        private bool _hasDiagonalArrows;
        private PlayerCharacteristics _playerCharacteristics;
        
        public DiagonalProjectileBuff(bool hasDiagonalArrows, PlayerCharacteristics playerCharacteristics)
        {
            _hasDiagonalArrows = hasDiagonalArrows;
            
            _playerCharacteristics = playerCharacteristics;
        }

        public void StartBuff()
        {
            _playerCharacteristics.DiagonalShells = _hasDiagonalArrows;
        }

        public void StopBuff()
        {
            _playerCharacteristics.DiagonalShells = !_hasDiagonalArrows;
        }
    }
}
