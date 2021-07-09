using Assets.Scripts.BattleManager;
using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    /// <summary>
    /// Класс отвечает за окно двери(предложение отправиться в комнату) и обработку кнопок
    /// </summary>
    public class DoorScreen : DungeonScreenTransition
    {
        private RoomSettings _roomSettings;
        
        public override void ApplyContext(PortalContext context)
        {
            base.ApplyContext(context);
            _roomSettings = context.RoomSettings;
        }

        [UsedImplicitly]
        public override void OnClick()
        {
            MainManager.ScreenManager.CloseTopScreen();
            DungeonManager.BattleManager.StartBattle(_roomSettings, _teleportPosition);
        }
    }
}