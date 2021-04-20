using Assets.Scripts.Managers.ScreensManager;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за открытие скрина с контекстом.
    /// </summary>
    public class BarrackScreenOpener : MonoBehaviour, IScreenOpenerWithContext
    {
        [SerializeField]
        private Barrack _barrack;

        public void ShowScreenWithContext()
        {
            var context = new BuildingContext()
            {
                Barrack = _barrack
            };

            MainManager.ScreenManager.OpenScreenWithContext(ScreenType.BarrackScreen,
                context);
        }
    }
}
