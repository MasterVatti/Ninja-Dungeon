using System.Collections.Generic;
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
    public class DoorScreen : BaseScreenWithContext<DungeonDoorContext>
    {
        private Vector3 _teleportPosition;
        private RoomSettings _roomSettings;

        [UsedImplicitly]
        public void TurnOffPanel()
        {
            MainManager.ScreenManager.CloseTopScreen();
        }

        public override void ApplyContext(DungeonDoorContext context)
        {
            _roomSettings = context.RoomSettings;
            _teleportPosition = context.TeleportPosition;
        }

        [UsedImplicitly]
        public void OnClick()
        {
            Debug.Log("CLICK");
            MainManager.ScreenManager.CloseTopScreen();
            MainManager.BattleManager.StartBattle(_roomSettings, _teleportPosition);
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}