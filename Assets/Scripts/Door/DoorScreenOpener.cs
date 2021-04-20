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
            var context = new PortalContext()
            {
                Description = _settings.ScreenDescription,
                SceneName = _settings.SceneName,
                DifficultyLevel = _settings.DifficultyLevel
            };
            
            MainManager.ScreenManager.OpenScreenWithContext(ScreenType.DoorScreen,
                context);
        }
    }
}
