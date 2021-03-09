using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace PlayerScripts
{
    /// <summary>
    /// Класс хранящий ресурсы игрока
    /// </summary>
    public class PlayerResourcesManager : MonoBehaviour
    {
        [SerializeField]
        private List<Resource> _resources;

        public static PlayerResourcesManager Instance { get; private set; }

        public List<Resource> CurrentResources => _resources;

        private void Awake ()
        {
            Instance = this;
        }
    }
}
