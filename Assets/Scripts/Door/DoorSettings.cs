using System;
using UnityEngine;

namespace Door
{
    /// <summary>
    /// Класс отвечает за настройки дверей(куда отправится и описание)
    /// </summary>
    [Serializable]
    public class DoorSettings
    {
        public string ScreenDescription => _screenDescription;
        public string SceneName => _sceneName;
        public string DifficultyLevel => _difficultyLevel;
    
        [SerializeField]
        private string _screenDescription;
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private string _difficultyLevel;

    }
}