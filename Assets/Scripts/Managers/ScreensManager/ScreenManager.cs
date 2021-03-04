using System;
using System.Collections.Generic;
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
        private List<BaseScreen> _screenList;
        private Stack<BaseScreen> _screenStack;

        private void Update()
        {
            if (Input.GetKeyUp("space"))
            {
                OpenScreen(ScreenType.RewardScreen,
                    new RewardScreenContext() {Gold = 200});
            }
        }

        public void OpenScreen(ScreenType screenType,
            BaseScreenContext screenContext)
        {
            var screenPrefab = FindScreenByType(screenType);
            screenPrefab.Initialize(screenType, screenContext);

            var screen = Instantiate(screenPrefab, _canvas.transform, false);
            
            // _screenStack.Push(screen);
        }

        public void CloseUpperScreen()
        {
            Destroy(_screenStack.Pop());
        }

        public void CloseAllScreens()
        {
            foreach (var screen in _screenStack)
            {
                Destroy(screen);
            }

            _screenStack.Clear();
        }

        public bool IsScreenOpened(ScreenType screenType)
        {
            if (FindScreenByType(screenType) == null)
            {
                return false;
            }

            return true;
        }

        private BaseScreen FindScreenByType(ScreenType screenType)
        {
            foreach (var screen in _screenList)
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
