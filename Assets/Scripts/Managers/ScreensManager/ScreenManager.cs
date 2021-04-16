using System;
using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using ResourceSystem;
using UnityEngine;

namespace Managers.ScreensManager
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
            if (IsScreenOpened(screenType))
            {
                return;
            }
            
            var screenPrefab = FindScreenByType<BaseScreen>(screenType);

            var screen = Instantiate(screenPrefab, _canvas.transform, false);

            InitializeScreen(screen, screenType);

            _screenStack.Push(screen);
        }

        /// <summary>
        /// Открывает окно с заданным контекстом
        /// </summary>
        public void OpenScreenWithContext<TContext>(ScreenType screenType,
            TContext context) where TContext : BaseContext
        {
            if (IsScreenOpened(screenType))
            {
                return;
            }
            
            var screenPrefab =
                FindScreenByType<BaseScreenWithContext<TContext>>(screenType);

            var screen = Instantiate(screenPrefab, _canvas.transform, false);

            InitializeScreen(screen, screenType);

            screen.ApplyContext(context);

            _screenStack.Push(screen);
        }

        public void CloseTopScreen()
        {
            if (_screenStack.Count == 0)
            {
                return;
            }
            
            var upperScreen = _screenStack.Pop();
            Destroy(upperScreen.gameObject);
        }

        public void CloseAllScreens()
        {
            foreach (var screen in _screenStack)
            {
                Destroy(screen.gameObject);
            }

            _screenStack.Clear();
        }
        
        private bool IsScreenOpened(ScreenType screenType)
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

        private void InitializeScreen(BaseScreen screen,
            ScreenType screenType)
        {
            if (screen == null)
            {
                throw new NotImplementedException($"You have not added {screenType} " +
                          "screen to screen list");
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
