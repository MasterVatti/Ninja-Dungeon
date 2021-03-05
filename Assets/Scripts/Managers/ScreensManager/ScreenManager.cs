using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Этот менеджер управляет окнами.
    /// То есть открывает окна, закрывает и т.д.
    /// </summary>
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;
        [SerializeField]
        private List<BaseScreen> _allScreens;

        private Stack<BaseScreen> _screenStack = new Stack<BaseScreen>();

        public void OpenScreen(ScreenType screenType,
            BaseScreenContext screenContext)
        {
            var screenPrefab = FindScreenByType(screenType);

            if (screenPrefab == null)
            {
                Debug.Log($"You have not added {screenType} "+
                          "screen to screen list");
                return;
            }

            screenPrefab.Initialize(screenType, screenContext);

            var screen = Instantiate(screenPrefab, _canvas.transform, false);

            _screenStack.Push(screen);
        }

        public void CloseTopScreen()
        {
            var upperScreen = _screenStack.Peek();
            Destroy(upperScreen.gameObject);

            _screenStack.Pop();
        }

        public void CloseAllScreens()
        {
            foreach (var screen in _screenStack)
            {
                Destroy(screen.gameObject);
            }

            _screenStack.Clear();
        }

        public bool IsScreenOpened(ScreenType screenType)
        {
            foreach (var screen in _screenStack)
            {
                if (screen.ScreenType == screenType)
                {
                    return true;
                }
            }

            return false;
        }

        private BaseScreen FindScreenByType(ScreenType screenType)
        {
            foreach (var screen in _allScreens)
            {
                if (screen.ScreenType == screenType)
                {
                    return screen;
                }
            }

            return null;
        }
    }
}
