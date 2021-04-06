using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    public class BarracksScreenOpener : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.BarrackScreen);
        }

        private void OnTriggerExit(Collider other)
        {
            MainManager.ScreenManager.CloseTopScreen();
        }
    }
}
