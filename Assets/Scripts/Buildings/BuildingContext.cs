using Barracks_and_allied_behavior;

namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Контекст зданий
    /// </summary>
    public class BuildingContext : BaseContext
    {
        public string BuildingName { get; set; }
        public Barrack Barrack { get; set; }
    }
}
