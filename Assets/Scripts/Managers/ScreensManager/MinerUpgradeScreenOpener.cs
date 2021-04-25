using Assets.Scripts;
using Assets.Scripts.Managers.ScreensManager;
using Buildings;
using BuildingSystem.BuildingUpgradeSystem;
using SaveSystem;
using UnityEngine;

namespace Managers.ScreensManager
{
    /// <summary>
    /// открывает окно улучшений ResourceMiner`a
    /// </summary>
    public class MinerUpgradeScreenOpener : MonoBehaviour
    {
        [SerializeField]
        private ResourceMiner _building;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                var context = new UpgradeContext<MinerBuildingData>
                {
                Building = _building
                };
                MainManager.ScreenManager.OpenScreenWithContext(ScreenType.MinerUpgradeScreen, context);
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
