using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using BuildingSystem;
using UnityEngine;

namespace Shop
{
    using SaveSystem;
    /// <summary>
    /// Отвечает за открытие какого-то экрана БЕЗ КОНТЕКСТА при подходе к нему
    /// и закрытию верхнего при отходе от здания
    /// </summary>
    public class ScreenOpener : Building<ShopData>
    {
        [SerializeField]
        private ScreenType _screenToOpen;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                MainManager.ScreenManager.OpenScreen(_screenToOpen);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                MainManager.ScreenManager.CloseTopScreen();
            }
        }
        
        protected override void Initialize(ShopData data)
        {
        }
    }
}
