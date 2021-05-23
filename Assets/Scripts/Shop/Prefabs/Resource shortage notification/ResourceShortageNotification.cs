using System;
using Assets.Scripts.Managers.ScreensManager;

namespace Shop.Prefabs.Resource_shortage_notification
{
    /// <summary>
    /// Представляет собой уведомление о том, что у игрока не хватает ресурсов
    /// </summary>
    public class ResourceShortageNotification : BaseScreen
    {
        public void OkButtonHandler()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
