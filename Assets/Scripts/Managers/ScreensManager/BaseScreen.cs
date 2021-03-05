using UnityEngine;

namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Этот базовый класс для представления экранов
    /// </summary>
    public abstract class BaseScreen : MonoBehaviour
    {
        public ScreenType ScreenType;

        /// <summary>
        /// Инициализирует окно без контекста.
        /// </summary>
        /// <param name="screenType">Тип экрана из ScreenType</param>
        public abstract void Initialize(ScreenType screenType);
    }
}
