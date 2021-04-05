using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Shop
{
    /// <summary>
    /// Скрипт вешается на префаб здания магазина и отвечает за открытие/закрытие магазина при подходе к нему
    /// </summary>
    public class ShopOpener : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.ShopScreen);
        }

        private void OnTriggerExit(Collider other)
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}
