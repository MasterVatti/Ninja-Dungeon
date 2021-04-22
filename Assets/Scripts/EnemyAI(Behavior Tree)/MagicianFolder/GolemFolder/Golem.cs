using Enemies;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    ///Отвечает за базовые характеристики Голема.
    /// </summary>
    public class Golem : Enemy
    {
        void Start()
        {
            CurrentHp = MaxHp;
        }
        
    }
}
