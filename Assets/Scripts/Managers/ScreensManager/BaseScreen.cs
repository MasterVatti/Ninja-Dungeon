using UnityEngine;

namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Этот базовый класс для представления экранов
    /// </summary>
    public abstract class BaseScreen : MonoBehaviour
    {
        protected GameObject _screenPrefab;
        public ScreenType ScreenType;

        /// <summary>
        /// Инициализирует окно.
        /// Именно в этом перезаписанном методе вы должны применить контекст,
        /// а также указать screenType для экрана
        /// </summary>
        /// <param name="screenType">Тип экрана из ScreenType</param>
        /// <param name="context">Контекст конкретного окна</param>
        /// <typeparam name="TContext">Тип контекста</typeparam>
        public abstract void Initialize<TContext>(ScreenType screenType,
            TContext context) where TContext : BaseScreenContext;
    }
}
