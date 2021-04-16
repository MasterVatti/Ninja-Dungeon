using Assets.Scripts;
using Panda;
using UnityEngine;

namespace Magician.Golem
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) голема (пока спавн голема и отбегание).
    /// </summary>
    public class GolemAI : MonoBehaviour
    {
        [SerializeField]
        private Unit _unit;
        
        private GameObject _player;
        
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag(GlobalConstants.PLAYER_TAG);
        }
        
        [Task]
        private void GetPlayerPoint()
        {
            _unit.SetColor(Color.green);

            _unit.ChangePointMovement(_player.transform.position);

            Task.current.Succeed();
        }
        
        [Task]
        private void Attack()
        {
            // Пока так, не реализованно хп игрока. Тут доработаю ( сиквенс до ээтого таска идет проверка
            // растояния 2f, если игрок в этом растоянии происходит атака, тут сделаем смотреть в сторону
            // игрока и анимация атаки. Получение урона игроком.)
            _unit.SetColor(Color.red);
            Task.current.Succeed();
        }
    }
}
