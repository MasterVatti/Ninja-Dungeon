using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Базовый класс для всех зданий
    /// </summary>
    public class BuildingBase
    {
        [SerializeField]
        private BuildingSettings _nextUpgrade;

        public void StartUpgrade ()
        {

        }
    }
}
