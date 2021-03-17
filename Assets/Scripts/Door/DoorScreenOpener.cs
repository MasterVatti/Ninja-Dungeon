using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Door
{
    /// <summary>
    /// Класс отвечает за открытие окна дверей
    /// </summary>
    public class DoorScreenOpener : MonoBehaviour, IPortalScreenOpener
    {
        [SerializeField]
        private DoorSettings _settings;
    
        public void ShowPortalScreen()
        {
            var context = new PortalContext()
            {
                Description = _settings.ScreenDescription,
                SceneName = _settings.SceneName,
                DifficultyLevel = _settings.DifficultyLevel
            };
            
            ScreenManager.Instance.OpenScreenWithContext(ScreenType.DoorScreen,
                context);
        }
    }
}
