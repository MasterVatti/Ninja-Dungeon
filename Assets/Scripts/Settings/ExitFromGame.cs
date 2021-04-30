using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// выход из игры (открывается экран подтверждения выхода)
    /// </summary>
    public class ExitFromGame : MonoBehaviour
    {
        public void OnClick()
        {
            ScreenManager.Instance.OpenScreen(ScreenType.AcceptScreen);
        }
    }
}
