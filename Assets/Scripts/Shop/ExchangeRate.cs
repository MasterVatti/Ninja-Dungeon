using System;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.Shop
{
    /// <summary>
    /// Представление курса
    /// </summary>
    [Serializable]
    public class ExchangeRate
    {
        public Resource SourceResource;
        public Sprite SourceResourceIcon;
        
        public Resource ResultResource;
        public Sprite ResultResourceIcon;
    }
}
