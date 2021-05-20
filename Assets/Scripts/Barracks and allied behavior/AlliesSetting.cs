using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за настройку листа союзников.
    /// </summary>
    [Serializable]
    public class AlliesSetting
    {
        public List<Resource> Price => _price;
        public string Description => _description;
        public GameObject AllyPrefab => _allyPrefab;
        public Sprite AllyIcon => _allyIcon;

        [SerializeField]
        private List<Resource> _price;
        [SerializeField]
        private Sprite _allyIcon;
        [SerializeField]
        private string _description;
        [SerializeField]
        private GameObject _allyPrefab;
    }
}