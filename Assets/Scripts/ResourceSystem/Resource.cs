using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ResourceSystem
{
    /// <summary>
    /// Класс для работы с ресурсами
    /// </summary>
    [Serializable]
    public struct Resource
    {
        public ResourceType Type
        {
            get => _type;
            set => _type = value;
        }

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        [SerializeField]
        private ResourceType _type;
        [SerializeField]
        private int _amount;
    }
}
