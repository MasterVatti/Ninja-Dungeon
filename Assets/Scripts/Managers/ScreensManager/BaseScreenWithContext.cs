namespace Assets.Scripts.Managers.ScreensManager
{
    /// <summary>
    /// Базовый класс для окон с контекстом
    /// Его необходимо использовать, если вы хотите выводить заданную вами
    /// информацию на окно.
    ///
    /// Пример: окно наград, на которое выводится количество монеток,
    /// заработанное пользователем
    /// </summary>
    public abstract class BaseScreenWithContext : BaseScreen
    {
        /// <summary>
        /// В перезаписи этого метода вы должны выводить контекст на экран 
        /// </summary>
        /// <param name="context">Контекст окна</param>
        /// <typeparam name="TContext">Тип контекста</typeparam>
        public abstract void ApplyContext<TContext>(TContext context)
            where TContext : BaseContext;
    }
}
