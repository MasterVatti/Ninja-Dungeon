using Assets.Scripts;
using JetBrains.Annotations;
using UnityEngine;

namespace NinjaDungeon.Scripts.StartMenu
{
    public class StartGameButton : MonoBehaviour
    {
        [UsedImplicitly]
        public void GoToUpperWorld()
        {
            MainManager.Instance.ResetPlayer();
            MainManager.JoystickController.gameObject.SetActive(true);
            MainManager.LoadingController.StartLoad(GlobalConstants.MAIN_SCENE_TAG);
        }
    }
}
