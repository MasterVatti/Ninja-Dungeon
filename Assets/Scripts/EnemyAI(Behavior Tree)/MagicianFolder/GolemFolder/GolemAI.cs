using Panda;
using UnityEngine;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) голема (пока спавн голема и отбегание).
    /// </summary>
    public class GolemAI : MonoBehaviour
    {
        [Task]
        private void Attack()
        {
            //TODO:
            // Пока так, не реализованно хп игрока. Тут доработаю ( сиквенс до ээтого таска идет проверка
            // растояния 2f, если игрок в этом растоянии происходит атака, тут сделаем смотреть в сторону
            // игрока и анимация атаки. Получение урона игроком.)
            Task.current.Succeed();
        }
    }
}
