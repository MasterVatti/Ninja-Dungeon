using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using BuildingSystem;
using BuildingSystem.BuildingUpgradeSystem;
using SaveSystem;
using UnityEngine;

namespace Managers.ScreensManager
{
    /// <summary>
    /// Отвечает за открытие экрана upgrade
    /// </summary>
    public class UpgradeScreenOpener<T> : MonoBehaviour where T : BaseBuildingState
    {
        [SerializeField]
        private Building<T> _building;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                var context = new UpgradeContext<T>
                {
                Building = _building
                };
                MainManager.ScreenManager.OpenScreenWithContext(ScreenType.UpgradeScreen, context);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                MainManager.ScreenManager.CloseTopScreen();
            }
        }
    }
}
