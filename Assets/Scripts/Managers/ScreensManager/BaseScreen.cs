﻿using UnityEngine;

namespace Managers.ScreensManager
{
    /// <summary>
    /// Этот базовый класс для представления экранов
    /// </summary>
    public abstract class BaseScreen: MonoBehaviour
    {
        protected GameObject _screenPrefab;
        public ScreenType ScreenType;
        public BaseScreenContext Context;

        public abstract void Initialize(ScreenType screenType,
            BaseScreenContext baseScreenContext);
    }
}
