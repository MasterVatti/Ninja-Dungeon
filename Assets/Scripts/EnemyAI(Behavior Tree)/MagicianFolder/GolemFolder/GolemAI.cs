using Characteristics;
using Panda;
using UnityEngine;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) голема (пока спавн голема и отбегание).
    /// </summary>
    public class GolemAI : MonoBehaviour
    {
        [SerializeField]
        private Unit _unit;
        
        private Player _player;
        
        private void Start()
        {
            _player = MainManager.Player;
        }
        
        [Task]
        private void SetDestinationPoint()
        {
            _unit.ChangePointMovement(_player.transform.position);
            Task.current.Succeed();
        }
        
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
