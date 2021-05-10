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
        public List<Resource> Price
        {
            get => _price;
            set => _price = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public GameObject AllyPrefab
        {
            get => _allyPrefab;
            set => _allyPrefab = value;
        }

        public Sprite AllyIcon
        {
            get => _allyIcon;
            set => _allyIcon = value;
        }

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