﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ResourceSystem
{
    /// <summary>
    /// Класс для работы с ресурсами
    /// </summary>
    [Serializable]
    public class Resource
    {
        public ResourceType Type
        {
            get => _type;
            set => _type = value;
        }

        public float Amount
        {
            get => _amount;
            set => _amount = value;
        }

        [SerializeField]
        private ResourceType _type;
        [SerializeField]
        private float _amount;
    }
}