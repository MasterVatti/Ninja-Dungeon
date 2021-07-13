using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// выход из игры (открывается экран подтверждения выхода)
    /// </summary>
    public class ExitFromGame : MonoBehaviour
    {
        [UsedImplicitly]
        public void ExitScreen()
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.AcceptScreen);
        }
    }
}
