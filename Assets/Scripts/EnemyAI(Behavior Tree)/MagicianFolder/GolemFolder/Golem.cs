using Enemies;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    /// Класс Голем, наследуемый от енеми.
    /// </summary>
    public class Golem : Enemy
    {
        void Start()
        {
            CurrentHp = MaxHp;
        }
        
    }
}
