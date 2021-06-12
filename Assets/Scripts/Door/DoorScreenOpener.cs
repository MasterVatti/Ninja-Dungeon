using Assets.Scripts.BattleManager;
using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Door
{
    /// <summary>
    /// Класс отвечает за открытие окна дверей
    /// </summary>
    public class DoorScreenOpener : MonoBehaviour, IScreenOpenerWithContext
    {
        [SerializeField]
        private DoorSettings _settings;
        
        public void ShowScreenWithContext()
        {
            var context = new DungeonDoorContext()
            {
                RoomSettings = _settings.RoomSettings,
                TeleportPosition = _settings.TeleportPosition
            };

            MainManager.ScreenManager.OpenScreenWithContext(ScreenType.DungeonDoorScreen,
                context);
        }
    }
}