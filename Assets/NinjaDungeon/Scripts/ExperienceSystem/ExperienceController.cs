using UnityEngine;

namespace ExperienceSystem
{
    /// <summary>
    /// Базовый класс для контроля опыта
    /// </summary>
    public abstract class ExperienceController : MonoBehaviour
    {
        public abstract void AddExperience(int value);
        public abstract void LevelUp();
        public abstract bool IsLevelMax();
    }
}

