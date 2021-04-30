using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Settings
{
    public class ExitFromGame : MonoBehaviour
    {
        public void OnClick()
        {
            ScreenManager.Instance.OpenScreen(ScreenType.AcceptScreen);
        }
    }
}
