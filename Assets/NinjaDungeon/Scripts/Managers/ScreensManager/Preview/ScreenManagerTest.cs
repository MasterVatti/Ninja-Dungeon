using Assets.Scripts.Managers.ScreensManager;
using Assets.Scripts.Managers.ScreensManager.Preview.RewardScreen;
using UnityEngine;

namespace NinjaDungeon.Scripts.Managers.ScreensManager.Preview
{
    /// <summary>
    /// Класс для тестирования фичи,
    /// этот вешается на коллайдер при столкновении с которым покажется
    /// тестовое окно
    /// </summary>
    public class ScreenManagerTest : MonoBehaviour
    {
        private void Start()
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.HelloScreen);
        }

        private void OnCollisionEnter(Collision other)
        {
            var context = new RewardContextExample {Gold = 300};
            MainManager.ScreenManager.OpenScreenWithContext(ScreenType.RewardScreen,
                context);
        }
    }
}
