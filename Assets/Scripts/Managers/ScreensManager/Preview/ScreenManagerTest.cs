using Assets.Scripts.Managers.ScreensManager.Preview.RewardScreen;
using UnityEngine;

namespace Assets.Scripts.Managers.ScreensManager.Preview
{
    /// <summary>
    /// Класс для тестирования фичи,
    /// этот вешается на коллайдер при столкновении с которым покажется
    /// тестовое окно
    /// </summary>
    public class ScreenManagerTest : MonoBehaviour
    {
        [SerializeField]
        private ScreenManager _screenManager;

        private void OnCollisionEnter(Collision other)
        {
            var context = new RewardScreenContext {Gold = 300};
            _screenManager.OpenScreen(ScreenType.RewardScreen, context);
        }
    }
}
