using Characteristics;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    ///Отвечает за базовые характеристики Голема.
    /// </summary>
    public class Golem : EnemyCharacteristics
    {
        void Start()
        {
            CurrentHp = MaxHp;
        }
        
    }
}
