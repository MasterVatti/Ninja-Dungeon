using Characteristics;

namespace MagicianFolder
{
    /// <summary>
    /// Класс отвечает за базовые характеристики Мага.
    /// </summary>
    public class Magician : EnemyCharacteristics
    {
        private void Start()
        {
            CurrentHp = MaxHp;
        }
    }
}
