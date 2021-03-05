using UnityEngine;

namespace PlayerScripts
{
    /// <summary>
    /// Класс хранящий ресурсы игрока
    /// </summary>
    public class PlayerResourcesManager : MonoBehaviour
    {
        private static int _currentGold = 200;
        private static int _currentLumber = 300;

        public static int[] CurrentResources
        {
            get => new[] {_currentGold, _currentLumber};
            set
            {
                _currentGold = value[0];
                _currentLumber = value[1];
            }
        }
    }
}
