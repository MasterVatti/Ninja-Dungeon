using Enemies;

namespace MagicianFolder
{
    /// <summary>
    /// Класс Маг, наследуемый от енеми.
    /// </summary>
    public class Magician : Enemy
    {
        private void Start()
        {
            CurrentHp = MaxHp;
        }
    }
}
