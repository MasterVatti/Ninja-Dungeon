using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// экран подтверждения выхода из игры
    /// </summary>
    public class AcceptScreen : BaseScreen
    {
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
        
        [UsedImplicitly]
        public void Exit()
        {
            Application.Quit();
        }
        
        [UsedImplicitly]
        public void TurnOffPanel()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}
