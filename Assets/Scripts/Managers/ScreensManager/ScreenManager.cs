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

        private readonly Stack<BaseScreen> _screenStack =
            new Stack<BaseScreen>();

        /// <summary>
        /// Открывает окно без контекста
        /// </summary>
        public void OpenScreen(ScreenType screenType)
        {
            var screenPrefab = FindScreenByType<BaseScreen>(screenType);

            InitializeScreen(screenPrefab, screenType);
            var screen = Instantiate(screenPrefab, _canvas.transform, false);

            _screenStack.Push(screen);
        }

        /// <summary>
        /// Открывает окно с заданным контекстом
        /// </summary>
        public void OpenScreenWithContext(ScreenType screenType,
            BaseContext context)
        {
            var screenPrefab =
                FindScreenByType<BaseScreenWithContext>(screenType);

            InitializeScreen(screenPrefab, screenType);
            screenPrefab.ApplyContext(context);

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

        private void InitializeScreen<TScreen>(TScreen screen,
            ScreenType screenType) where TScreen : BaseScreen
        {
            if (screen == null)
            {
                Debug.Log($"You have not added {screenType} " +
                          "screen to screen list");
                return;
            }

            screen.Initialize(screenType);
        }

        private TScreen FindScreenByType<TScreen>(ScreenType screenType)
            where TScreen : BaseScreen
        {
            foreach (var screen in _allScreens)
            {
                if (screen.ScreenType == screenType)
                {
                    return screen as TScreen;
                }
            }

            return null;
        }
    }
}
