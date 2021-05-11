using System;
using UnityEngine;

namespace Characteristics
{
    [Serializable]
    public class Characteristic
    {
        public int Level { get; set; }
        public int StepValue => _stepValue;
        public int CurrentValue => _baseValue + Level * StepValue;
        public CharacteristicType Type => _type;

        [SerializeField]
        private int _baseValue;
        [SerializeField]
        private int _stepValue;
        [SerializeField]
        private CharacteristicType _type;
    }
}
