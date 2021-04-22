using Enemies;

namespace MagicianFolder
{
    /// <summary>
    /// Класс отвечает за базовые характеристики Мага.
    /// </summary>
    public class Magician : Enemy
    {
        private void Start()
        {
            CurrentHp = MaxHp;
        }
    }
}
