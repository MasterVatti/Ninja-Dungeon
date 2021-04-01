using System;
using ResourceSystem;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class ExchangeRate
    {
        public Resource SourceResource;
        public Sprite SourceResourceIcon;
        
        public Resource ResultResource;
        public Sprite ResultResourceIcon;
    }
}
