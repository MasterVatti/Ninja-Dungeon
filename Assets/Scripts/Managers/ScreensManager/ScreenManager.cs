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
        private List<BaseScreen> _allScreens;

        private readonly Stack<BaseScreen> _screenStack =
            new Stack<BaseScreen>();

        /// <summary>
        /// Открывает окно без контекста
        /// </summary>
        public void OpenScreen(ScreenType screenType)
        {
            var screenPrefab = FindScreenByType<BaseScreen>(screenType);
            
            var screen = Instantiate(screenPrefab, gameObject.transform, false);
            
            InitializeScreen(screenPrefab, screenType);
            
            _screenStack.Push(screen);
        }

        /// <summary>
        /// Открывает окно с заданным контекстом
        /// </summary>
        public void OpenScreenWithContext<TContext>(ScreenType screenType,
            TContext context) where TContext: BaseContext
        {
            var screenPrefab =
                FindScreenByType<BaseScreenWithContext<TContext>>(screenType);
            
            var screen = Instantiate(screenPrefab, gameObject.transform, false);
            
            InitializeScreen(screenPrefab, screenType);
            
            screen.ApplyContext(context);
            
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

        private void InitializeScreen(BaseScreen screen,
            ScreenType screenType)
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
