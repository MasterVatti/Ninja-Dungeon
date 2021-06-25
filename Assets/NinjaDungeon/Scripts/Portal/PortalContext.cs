using Assets.Scripts.BattleManager;
using UnityEngine;

namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Контекст портала и дверей
    /// </summary>
    public class PortalContext : BaseContext
    {
        public string Description { get; set; }
        public string SceneName { get; set; }
        public string DifficultyLevel { get; set; }
        public Vector3 TeleportPosition { get; set; }
    }
}